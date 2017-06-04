using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public abstract class Tile : MonoBehaviour
	{
		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{}
			
		public void OnTriggerEnter2D(Collider2D other){
			if (other.gameObject.tag == "Player") 
			{
				CharacterEntered (other.GetComponent<Character> ());
			}
		}

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                CharacterEntered(other.gameObject.GetComponent<Character>());
            }
        }

        public abstract void CharacterEntered(Character character);
	}
}

