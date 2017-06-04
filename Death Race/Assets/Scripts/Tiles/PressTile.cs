using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class PressTile : DeathTile {

    public override void CharacterEntered(Character character)
    {
        //base.CharacterEntered(character);

        if (activated && character.transform.position.y < (transform.position.y - 0.2f))
        {
            Deactivate();
            trap.Trigger();
            character.Die(trap);
            spr = character.deathSprite(trap.causeOfDeath);

            AudioSource src = GetComponent<AudioSource>();
            if (src && _clipToPlay)
            {
                src.clip = _clipToPlay;
                src.Play();
            }
        }

    }
}
