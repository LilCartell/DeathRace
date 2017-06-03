using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public abstract class Trap : MonoBehaviour
	{
		public abstract void ActivateTrap ();
		public abstract void DeactivateTrap();
	}
}

