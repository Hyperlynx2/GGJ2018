using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public enum Direction
    {
        up, down, left, right
    }

    //Constant
    public float flowRate;

    //Public variables
    public bool up, down, left, right;          //Booleans for which directions the pipe leads.
    public bool upSource, downSource, leftSource, rightSource;  //Bools for which direction the water source is.

    //Private variables
    protected int x, y;
    protected TileManager tileManager;
    protected ScoreManager scoreManager;
    protected float waterPercentage;
    private float prevWaterPercentage;
    private int endGameChecker;

    void Start()
    {
        //Calculate the position of the tile as an integer
        x = (int)Math.Round(this.transform.position.x);
        y = (int)Math.Round(this.transform.position.y);
        tileManager = GameObject.FindObjectOfType<TileManager>();       //Store the TileManager as a variable
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();     //Store the scoreManager as a variable
        startTile();
        tileManager.setTile(this, x, y);
    }

    void FixedUpdate()
    {
        updateTile();
     
        prevWaterPercentage = waterPercentage;

    }

    public bool isFlowing()
    {
        Debug.Log(waterPercentage);
        if(prevWaterPercentage == waterPercentage)
        {
            return true;
        }
        return false;
    }

    public bool getPipeDir(Direction dir)
    {
        switch(dir)
        {
            case Direction.up: return up;
            case Direction.right: return right;
            case Direction.down: return down;
            case Direction.left: return left;
        }
        return false;
    }

    public virtual void rotateLeft()
    {
    }

    public virtual void rotateRight()
    {
    }

    public void addWater(float water)
    {
        waterPercentage += water;
    }

    public float getWaterPercentage()
    {
        return waterPercentage;
    }

    public void setSource(Direction dir)
    {
        switch(dir)
        {
            case Direction.up: upSource = true;
                break;
            case Direction.right: rightSource = true;
                break;
            case Direction.down: downSource = true;
                break;
            case Direction.left: leftSource = true;
                break;
        }
    }

    protected void propogateWater()
    {
        List<Tile> nextTiles = new List<Tile>(4);
        Tile tile;

        //Calculate how many exits the water is flowing through
        float exitCount = 0;
        if (up && !upSource)
        {
            tile = tileManager.getTile(x, y + 1);
            if (tile != null)        //Check that the tile is not out of bounds
            {
                //Check that the tile faces the right direction
                if (tile.getPipeDir(Direction.down))
                {
                    //Check that the pipe isnt full of water
                    if(tile.getWaterPercentage() < 1)
                    {
                        tile.setSource(Direction.down);
                        exitCount++;
                        nextTiles.Add(tile);
                    }
                }
            }
        }
        if (down && !downSource)
        {
            tile = tileManager.getTile(x, y - 1);
            if (tile != null)
            {
                if (tile.getPipeDir(Direction.up))
                {
                    if (tile.getWaterPercentage() < 1)
                    {
                        tile.setSource(Direction.up);
                        exitCount++;
                        nextTiles.Add(tile);
                    }
                }
            }
        }
        if (left && !leftSource)
        {
            tile = tileManager.getTile(x - 1, y);
            if (tile != null)
            {
                if (tile.getPipeDir(Direction.right))
                {
                    if (tile.getWaterPercentage() < 1)
                    {
                        tile.setSource(Direction.right);
                        exitCount++;
                        nextTiles.Add(tile);
                    }
                }
            }
        }
        if (right && !rightSource)
        {
            tile = tileManager.getTile(x + 1, y);
            if (tile != null)
            {
                if (tile.getPipeDir(Direction.left))
                {
                    if (tile.getWaterPercentage() < 1)
                    {
                        tile.setSource(Direction.left);
                        exitCount++;
                        nextTiles.Add(tile);
                    }
                }
            }
        }

        //Calculate the flow to each pipe
        float splitFlow = (flowRate / exitCount);

        //Move the water to the exit pipes.
        foreach(Tile t in nextTiles)
        {
            t.addWater(splitFlow);
            waterPercentage -= splitFlow;
        }
    }

    public abstract void startTile();
    public abstract void updateTile();

}
