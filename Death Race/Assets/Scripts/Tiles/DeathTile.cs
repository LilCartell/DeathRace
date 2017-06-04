using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class DeathTile : Tile
	{
		public bool ReplaceWithDeadBody = false;
		public bool Periodic = false;
		public float TimeBetweenActivations = 20f;
		protected float _timeSinceDeactivation = 0;
        public AudioClip _clipToPlay;
        public Vector3 _deadBodySpawnPosition;

        protected Sprite spr;

        protected bool activated;
		protected Trap trap;

		public bool Activated{get { return activated;}}

		protected override void Awake()
		{
			base.Awake ();
			trap = GetComponentInChildren<Trap> ();
		}

        public void Start()
        {
			Activate ();
        }

        protected override void Update()
		{
			base.Update ();
			if (Periodic && !activated)
			{
				_timeSinceDeactivation += Time.deltaTime;
				if (_timeSinceDeactivation >= TimeBetweenActivations) 
				{
					Activate ();
				}
			}

		}

		public override void CharacterEntered(Character character)
		{
            print(name + " : Character entered");
			if (activated) 
			{
				Deactivate ();				
				trap.Trigger ();
				character.Die (trap);
                spr = character.deathSprite(trap.causeOfDeath);

                AudioSource src = GetComponent<AudioSource>();
                if (src && _clipToPlay)
                {
                    src.clip = _clipToPlay;
                    src.Play();
                }
			}
		}

		public virtual void Activate()
		{
            //print("Activate");
			if (trap != null) 
			{
				trap.Activate ();
				activated = true;
			}
		}

		public void OnFinishedKill(){
            print(name + " : on finished kill");
			if (ReplaceWithDeadBody) {
                GameObject temp = GameObject.Instantiate<GameObject>(new GameObject(), transform.position, transform.rotation);
                var spR = temp.AddComponent<SpriteRenderer>();
                var coll = temp.AddComponent<BoxCollider2D>();
                coll.isTrigger = false;
                coll.size = new Vector2(1, 0.8f);
                spR.sprite = spr;
                temp.transform.parent = transform;
                temp.transform.position = transform.position + _deadBodySpawnPosition;
                temp.layer = 9;
			}
		}

		public virtual void Deactivate(){
			activated = false;
			_timeSinceDeactivation = 0f;
		}
	}
}

