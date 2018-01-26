using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    //Constant
    public int TIMETOFILL;

    //Public variables
    public bool up, down, left, right;          //Booleans for which directions the pipe leads.

    //Private variables
    protected int x, y;
    protected TileManager tileManager;
    protected ScoreManager scoreManager;

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

    public virtual void rotateLeft()
    {
    }

    public virtual void rotateRight()
    {
    }

    protected void propogateWater()
    {
        Tile nextTile;

        if(up)
        {
            nextTile = tileManager.getTile(x, y + 1);
            if(nextTile != null)
            {
                nextTile.startFilling();
            }
        }
        if(down)
        {
            nextTile = tileManager.getTile(x, y - 1);
            if (nextTile != null)
            {
                nextTile.startFilling();
            }
        }
        if (left)
        {
            nextTile = tileManager.getTile(x - 1, y);
            if (nextTile != null)
            {
                nextTile.startFilling();
            }
        }
        if (right)
        {
            nextTile = tileManager.getTile(x + 1, y);
            if (nextTile != null)
            {
                nextTile.startFilling();
            }
        }
    }

    public abstract void startTile();
    public abstract void updateTile();
    public abstract void startFilling();
}
