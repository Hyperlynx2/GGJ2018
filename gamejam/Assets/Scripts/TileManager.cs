using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //public variables
    public int width, height;

    //Private variables
    private List<Tile> tileList;


    //allows initializing on first use, as late as possible.
    private void init()
    {
        if (tileList == null)
        {
            tileList = new List<Tile>(width * height);
            for (int i = 0; i < width * height; i++)
            {
                tileList.Add(null);
            }
        }
    }


    public Tile getTile(int x, int y)
    {
        init();
        return tileList[y * width + x];
    }

    public void setTile(Tile tile, int x, int y)
    {
        init();
        tileList[y * width + x] = tile;
        if(y == 0 && x == 0)
        {
            tileList[0].startFilling();
        }
    }

    // Anything in this position?
    public bool isEmpty(Vector3 position)
    {
        //just in case we change to having actual tiles that are blank, to shape the level.
        return getTile((int)System.Math.Round(position.x),
                       (int)System.Math.Round(position.y)) == null;
    }

    // Helper function. Is this space in play?
    public bool isTileInPlay(int x, int y)
    {
        return x >= 0 && x <= width && y >= 0 && y <= height;
    }

    public bool isTileInPlay(float x, float y)
    {
        return isTileInPlay((int)System.Math.Round(x), (int)System.Math.Round(y));
    }
}
