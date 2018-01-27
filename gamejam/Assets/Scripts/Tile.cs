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
    public int TIMETOFILL;

    //Public variables
    public bool up, down, left, right;          //Booleans for which directions the pipe leads.
    public bool upSource, downSource, leftSource, rightSource;  //Bools for which direction the water source is.

    //Private variables
    protected int x, y;
    protected TileManager tileManager;
    protected ScoreManager scoreManager;
    protected float waterPercentage;

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

    void Update()
    {
        updateTile();
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
        Tile nextTile;

        if(up && !upSource)
        {
            nextTile = tileManager.getTile(x, y + 1);
            if(nextTile != null)        //Check that the tile is not out of bounds
            {
                //Check that the tile faces the right direction
                if(nextTile.getPipeDir(Direction.down))
                {
                    nextTile.setSource(Direction.down);
                    nextTile.addWater(0.01f);
                    waterPercentage -= 0.01f;
                }
            }
        }
        if(down && !downSource)
        {
            nextTile = tileManager.getTile(x, y - 1);
            if (nextTile != null)
            {
                if (nextTile.getPipeDir(Direction.up))
                {
                    nextTile.setSource(Direction.up);
                    nextTile.addWater(0.01f);
                    waterPercentage -= 0.01f;
                }
            }
        }
        if (left && !leftSource)
        {
            nextTile = tileManager.getTile(x - 1, y);
            if (nextTile != null)
            {
                if (nextTile.getPipeDir(Direction.right))
                {
                    nextTile.setSource(Direction.right);
                    nextTile.addWater(0.01f);
                    waterPercentage -= 0.01f;
                }
            }
        }
        if (right && !rightSource)
        {
            nextTile = tileManager.getTile(x + 1, y);
            if (nextTile != null)
            {
                if (nextTile.getPipeDir(Direction.left))
                {
                    nextTile.setSource(Direction.left);
                    nextTile.addWater(0.01f);
                    waterPercentage -= 0.01f;
                }
            }
        }
    }

    public abstract void startTile();
    public abstract void updateTile();
    public abstract void startFilling();
}
