using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Tile {

    //Private variables
    private bool hasBeenFilled;

    // Use this for initialization
    public override void startTile ()
    {
        hasBeenFilled = false;
        waterPercentage = 0;
	}
	
	// Update is called once per frame
	public override void updateTile ()
    {
        if (waterPercentage < 1)
        {
            if (hasBeenFilled)
            {
                propogateWater();

            }
        }
        else
        {
            hasBeenFilled = true;
            this.GetComponent<SpriteRenderer>().material.color = Color.blue;
            propogateWater();
        }

        if(waterPercentage <= 0)
        {
            hasBeenFilled = false;
            this.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }

    public override void rotateLeft()
    {
        bool tempUp = up;
        up = right;
        right = down;
        down = left;
        left = tempUp;
    }

    public override void rotateRight()
    {
        bool tempUp = up;
        up = left;
        left = down;
        down = right;
        right = tempUp;
    }

    public override void startFilling()
    {
    }
}
