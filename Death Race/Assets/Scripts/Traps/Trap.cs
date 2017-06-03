using System;
using UnityEngine;

namespace AssemblyCSharp
{
	[RequireComponent(typeof(Animator))]
	public class Trap : MonoBehaviour
	{
		public CauseOfDeath causeOfDeath;
		public int ScoreModifier;
		private Animator _animator;

		protected virtual void Awake()
		{
			_animator = GetComponent<Animator> ();
		}

		public void Activate () 
		{
			_animator.SetTrigger ("Activate");
		}
			
		public void Trigger ()
		{
			_animator.SetTrigger ("Kill");
		}

		public void KillAnimationOver ()
		{
			GetComponentInParent<DeathTile> ().OnFinishedKill ();
		}
	}
}

