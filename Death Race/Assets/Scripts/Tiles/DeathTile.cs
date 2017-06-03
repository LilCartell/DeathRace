using System;

namespace AssemblyCSharp
{
	public class DeathTile : Tile
	{
		public bool ReplaceWithDeadBody = false;

		private bool activated;
		protected Trap trap;

		public bool Activated{get { return activated;}}

		protected override void Awake(){
			base.Awake ();
			trap = GetComponentInChildren<Trap> ();
			Activate ();
		} 

		public override void CharacterEntered(Character character)
		{
			if (activated) 
			{
				trap.Trigger ();
				character.Die (trap);
			}
		}

		public virtual void Activate()
		{
			if (trap != null) 
			{
				trap.Activate ();
				activated = true;
			}
		}

		public void OnFinishedKill(){
			Deactivate ();
			if (ReplaceWithDeadBody) {
				//TODO Place a dead body to step on instead of the tile 
			}
		}

		public virtual void Deactivate(){
			activated = false;
		}
	}
}

