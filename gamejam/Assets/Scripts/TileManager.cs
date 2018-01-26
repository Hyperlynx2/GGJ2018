using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    //public variables
    public int width, height;

    //Private variables
    private List<Tile> tileList;

    //gets a tile from the tile from the list by x and y coords
    public Tile getTile(int x, int y)
    {
        if(x >= 0 && x < width && y >= 0 && y < height)
        {
            return tileList[y * width + x];
        }
        return null;
    }

    //Puts a tile in the list based on x and y coords
    public void setTile(Tile tile, int x, int y)
    {
        if(tileList == null)
        {
            tileList = new List<Tile>(width * height);
            for(int i = 0; i < width*height; i++)
            {
                tileList.Add(null);
            }
        }
        tileList[y * width + x] = tile;
        if(y == 0 && x == 0)
        {
            tileList[0].startFilling();
        }
    }

}
