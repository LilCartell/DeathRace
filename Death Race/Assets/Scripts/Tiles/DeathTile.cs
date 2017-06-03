using System;

namespace AssemblyCSharp
{
	public class DeathTile : Tile
	{
		private bool activated = true;
		protected Trap trap;

		protected override void Awake(){
			base.Awake ();
			trap = GetComponentInChildren<Trap> ();
		} 

		public override void OnEntryFrom(Character character)
		{
			if (activated) 
			{
				//TODO Launch anim for trap ?
				character.Die (); //TODO Add cause of death ?

			}
		}

		public virtual void Activate()
		{
			//TODO Launch anim for trap activation (landmine goes click, circular saw starts moving...)
			activated = true;
		}

		public virtual void Deactivate(){
			//TODO Launch anim for trap deactivation
			activated = false;
		}
	}
}

