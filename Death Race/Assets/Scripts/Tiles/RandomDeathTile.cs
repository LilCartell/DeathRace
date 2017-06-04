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
            print(trapPrefab.name);
			var newTrap = Instantiate<GameObject> (trapPrefab);
			newTrap.transform.SetParent (transform);
			newTrap.transform.localPosition = new Vector3(0, 1, 0);
			newTrap.transform.localScale = Vector3.one;
			newTrap.transform.localRotation = Quaternion.identity;
			trap = newTrap.GetComponent<Trap> ();
			Activate ();
		}

		public override void Deactivate(){
			base.Deactivate ();
			Destroy (trap);
		}
	}
}

