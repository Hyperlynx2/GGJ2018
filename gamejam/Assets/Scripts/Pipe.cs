using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Tile {

    // Use this for initialization
    public override void startTile ()
    {
        waterPercentage = 0;
	}

    // Update is called once per frame
    public override void updateTile()
    {
        Color pipeColor = new Color(1 - waterPercentage, 1 - waterPercentage, 1);
        this.GetComponent<SpriteRenderer>().material.color = pipeColor;

       


        if (waterPercentage < 1 && waterPercentage > 0)
        {
            //Check to see if there is no water in the source, in which case it needs to push the water.
            if (upSource)
            {
                if (tileManager.getTile(x, y + 1).getWaterPercentage() <= 0.0f)
                {
                    propogateWater();
                }
            }
            if (downSource)
            {
                if (tileManager.getTile(x, y - 1).getWaterPercentage() <= 0.0f)
                {
                    propogateWater();
                }
            }
            if (leftSource)
            {
                if (tileManager.getTile(x - 1, y).getWaterPercentage() <= 0.0f)
                {
                    propogateWater();
                }
            }
            if (rightSource)
            {
                if (tileManager.getTile(x + 1, y).getWaterPercentage() <= 0.0f)
                {
                    propogateWater();
                }
            }
        }
        else if(waterPercentage >= 1)
        {
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
}
