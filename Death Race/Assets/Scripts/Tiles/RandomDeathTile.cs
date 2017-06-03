using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class RandomDeathTile : DeathTile
	{
		protected override void Awake()
		{
			base.Awake ();

		}

		public void SpawnNewTrap(GameObject trapPrefab)
		{
			var newTrap = Instantiate<GameObject> (trapPrefab);
			newTrap.transform.SetParent (transform);
			newTrap.transform.localPosition = Vector3.zero;
			newTrap.transform.localScale = Vector3.one;
			newTrap.transform.localRotation = Quaternion.identity;
			trap = newTrap.GetComponent<Trap> ();
			Activate ();
		}

		public void FinishDeactivate(){
			Destroy (trap);
		}
	}
}

