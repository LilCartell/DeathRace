using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class DeathTile : Tile
	{
		public bool ReplaceWithDeadBody = false;
		public bool Periodic = false;
		public float TimeBetweenActivations = 20f;
		private float _timeSinceDeactivation = 0;

		private bool activated;
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
            print("Character entered");
			if (activated) 
			{
				Deactivate ();				
				trap.Trigger ();
				character.Die (trap);
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
            print("on finished kill");
			if (ReplaceWithDeadBody) {
				//TODO Place a dead body to step on instead of the tile 
			}
		}

		public virtual void Deactivate(){
            print("deactivate");
			activated = false;
			_timeSinceDeactivation = 0f;
		}
	}
}

