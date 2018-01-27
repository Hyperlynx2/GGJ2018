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
        Color pipeColor = new Color(1 - waterPercentage, 1 - waterPercentage, 1);
        this.GetComponent<SpriteRenderer>().material.color = pipeColor;

        if (waterPercentage < 1 && waterPercentage > 0)
        {
            if (hasBeenFilled)
            {
                propogateWater();

            }
        }
        else if(waterPercentage >= 1)
        {
            hasBeenFilled = true;
            propogateWater();
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
