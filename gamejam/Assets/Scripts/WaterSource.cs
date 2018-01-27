using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : Tile {

    //Public variables
    public int timeTilStart;

    //Private variables
    private float countdownTimer;

	// Use this for initialization
	public override void startTile ()
    {
        countdownTimer = timeTilStart;
        waterPercentage = 5;
    }
	
	// Update is called once per frame
	public override void updateTile ()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0)
        {
            if(waterPercentage > 0)
            {
                propogateWater();
            }
        }
	}
}
