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
            Debug.Log(hasWater);
            if (hasWater)
            { 
                waterPercentage += Time.deltaTime / (float)TIMETOFILL;
                Debug.Log(waterPercentage);
            }
            if(waterPercentage >= 1)
            {
                propogateWater();
            }
        }
	}

    public override void startFilling()
    {
        Debug.Log("pipe starting");
        hasWater = true;
    }
}
