using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor: MonoBehaviour
{
    // Set per player. Used to tell what inputs to get.
    public string horizontalAxis;
    public string verticalAxis;
    
    
    //TODO: ABXY buttons

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /* TODO: psuedo: 
        if input delay has expired:
            change the position we're interested in based on current position, to next integer.
            (later) ask the tile manager if there's a tile in that position, and if so move to that position.
        endif
        */


        Debug.Log(Input.GetAxis(horizontalAxis) + ", " + Input.GetAxis(verticalAxis));

        

    }
}
