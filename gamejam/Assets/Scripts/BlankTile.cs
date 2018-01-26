using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankTile : Tile {

    public override void startTile()
    {

    }

    // Update is called once per frame
    public override void updateTile()
    {

    }

    public override void startFilling()
    {
        Debug.Log("Water overflowing");
    }
}
