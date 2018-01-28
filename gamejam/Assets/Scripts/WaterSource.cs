using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSource : Tile {

    //Public variables
    public int timeTilStart;

    //Private variables
    private float countdownTimer;

    public AudioClip startFillingSound;
    public AudioClip countDownSound;

    private bool soundBool;

    // Use this for initialization
    public override void startTile ()
    {
        countdownTimer = timeTilStart;
        waterPercentage = 5;
        soundBool = true;
    }
	
	// Update is called once per frame
	public override void updateTile ()
    {

        checkForPipes();
       
        countdownTimer -= Time.deltaTime;

        if(countdownTimer <= 3)
        {
            if (soundBool)
            {
                AudioManager.getInstance().playOnce(startFillingSound);
                soundBool = false;
            }
        }

        if (countdownTimer <= 0)
        {                
            if (waterPercentage > 0)
            {
                propogateWater();
                if(!up && !down && ! left && !right)
                {
                    waterPercentage -= flowRate;
                }
            }
        }
	}

    private void checkForPipes()
    {
        Tile tile;
        tile = tileManager.getTile(x, y + 1);
        if (tile != null && tile is Pipe)        //Check that the tile is not out of bounds
        {
            //Check that the tile faces the right direction
            if (tile.getPipeDir(Direction.down))
            {
                //Check that the pipe isnt full of water
                if (tile.getWaterPercentage() < 1)
                {
                    up = true;
                }
            }
        }
      
        tile = tileManager.getTile(x, y - 1);
        if (tile != null && tile is Pipe)
        {
            if (tile.getPipeDir(Direction.up))
            {
                if (tile.getWaterPercentage() < 1)
                {
                    down = true;
                }
            }
        }
        
        tile = tileManager.getTile(x - 1, y);
        if (tile != null && tile is Pipe)
        {
            if (tile.getPipeDir(Direction.right))
            {
                if (tile.getWaterPercentage() < 1)
                {
                    left = true;
                }
            }
        }
      
        tile = tileManager.getTile(x + 1, y);
        if (tile != null && tile is Pipe)
        {
            if (tile.getPipeDir(Direction.left))
            {
                if (tile.getWaterPercentage() < 1)
                {
                    right = true;
                }
            }
        }

    }

}
