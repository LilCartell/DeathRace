using System;
using UnityEngine;

namespace AssemblyCSharp
{
	//[RequireComponent(typeof(Animator))]
	public class Trap : MonoBehaviour
	{
		public CauseOfDeath causeOfDeath;
		public int ScoreModifier;
		private Animator _animator;

		protected virtual void Awake()
		{
            print("Awake Animation");
            print(GetComponent<Animator>());
			_animator = GetComponent<Animator> ();
		}

        public void Activate () 
		{
            print("Activated animation");
            //if (_animator)
    			_animator.SetTrigger ("Activate");
		}
			
		public void Trigger ()
		{
            print("Triggered animation");
			_animator.SetTrigger ("Kill");
		}

		public void KillAnimationOver ()
		{
			GetComponentInParent<DeathTile> ().OnFinishedKill ();
		}
	}
}

