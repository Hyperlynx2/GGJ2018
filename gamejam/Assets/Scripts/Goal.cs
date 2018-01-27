using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Tile {

    public bool playerOne;

    public override void startTile()
    {

    }

    // Update is called once per frame
    public override void updateTile()
    {
        if(waterPercentage > 0)
        {
            scoreManager.incrementScore(playerOne, waterPercentage);
            waterPercentage = 0;
        }
    }
}



