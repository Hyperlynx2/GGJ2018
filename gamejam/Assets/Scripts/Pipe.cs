using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : Tile {

    //Private variables
    private bool hasWater;
    private float waterPercentage;

    // Use this for initialization
    public override void startTile ()
    {
        hasWater = false;
        waterPercentage = 0;
	}
	
	// Update is called once per frame
	public override void updateTile ()
    {
        if (waterPercentage < 1)
        {
            if (hasWater)
            { 
                waterPercentage += Time.deltaTime / (float)TIMETOFILL;
                Debug.Log(waterPercentage);
            }
            if(waterPercentage >= 1)
            {
                this.GetComponent<SpriteRenderer>().material.color = Color.blue;
                propogateWater();
            }
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
        hasWater = true;
    }
}
