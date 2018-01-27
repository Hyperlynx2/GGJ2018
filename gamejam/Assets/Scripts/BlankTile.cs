using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankTile : Tile {

    private bool colourChange;

    public override void startTile()
    {
        colourChange = false;
        waterPercentage = 0;
    }

    // Update is called once per frame
    public override void updateTile()
    {
        if(waterPercentage >= 1)
        {
            waterPercentage = 0.0f;
        }
    }

    public override void startFilling()
    {
        Debug.Log("Water overflowing");
    }
}
