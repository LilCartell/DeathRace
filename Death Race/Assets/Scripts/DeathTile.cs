using System;

namespace AssemblyCSharp
{
	public class DeathTile : Tile
	{
		public override void OnEntryFrom(Character character)
		{
			//TODO Launch anim for trap ?
			character.StartDeath (); //TODO Add cause of death ?
		}
	}
}

