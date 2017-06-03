using System;

namespace AssemblyCSharp
{
	public class DeathTile : Tile
	{
		private bool activated = true;

		public override void OnEntryFrom(Character character)
		{
			if (activated) 
			{
				//TODO Launch anim for trap ?
				character.StartDeath (); //TODO Add cause of death ?
				activated = false;
			}
		}

		public void Activate()
		{
			//TODO Launch anim for trap activation (landmine goes click, circular saw starts moving...)
			activated = true;
		}
	}
}

