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

    void Start()
    {
        x = (int)Math.Round(this.transform.position.x);
        y = (int)Math.Round(this.transform.position.y);
        tileManager = GameObject.FindObjectOfType<TileManager>();
        startTile();
        tileManager.setTile(this, x, y);
    }

    void Update()
    {
        updateTile();
    }

    protected void propogateWater()
    {
        Tile nextTile;

        if(up)
        {
            nextTile = tileManager.getTile(x, y - 1);
            nextTile.startFilling();
        }
        if(down)
        {
            nextTile = tileManager.getTile(x, y + 1);
            nextTile.startFilling();
        }
        if (left)
        {
            nextTile = tileManager.getTile(x - 1, y);
            nextTile.startFilling();
        }
        if (right)
        {
            nextTile = tileManager.getTile(x + 1, y);
            nextTile.startFilling();
        }
    }

    public abstract void startTile();
    public abstract void updateTile();
    public abstract void startFilling();
}
