using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankTile : Tile {

    private bool colourChange;

    public override void startTile()
    {
        waterPercentage = 0;
    }

    // Update is called once per frame
    public override void updateTile()
    {
        waterPercentage = 0;
    }
}
