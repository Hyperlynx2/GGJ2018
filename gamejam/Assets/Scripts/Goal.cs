using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Tile {

    public bool playerOne;

    // Use this for initialization
    public override void startTile()
    {
        //Sets colour of the goal based on which player it is for.
        if(playerOne)
        {
            this.GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().material.color = Color.blue;
        }
    }

    // Update is called once per frame
    public override void updateTile()
    {

    }

    public override void startFilling()
    {
        //Increment the score of the owner of the goal.
        scoreManager.incrementScore(playerOne);
    }
}



