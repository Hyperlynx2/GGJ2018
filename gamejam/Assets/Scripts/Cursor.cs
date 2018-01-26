using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Cursor: MonoBehaviour
{
    // Set per player. Used to tell what inputs to get.
    public string horizontalAxis;
    public string verticalAxis;

    //TODO: ABXY buttons

    // Seconds between accepting input.
    public float inputDelay;

    private float inputDelayRemaining = 0;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (inputDelayRemaining > 0)
        {
            inputDelayRemaining -= Time.deltaTime * inputDelay;
        }
        else
        {
            float newX = transform.position.x;
            float newY = transform.position.y;

            if (Input.GetAxis(horizontalAxis) < 0)
            {
                newX--;
            }
            else if (Input.GetAxis(horizontalAxis) > 0)
            {
                newX++;
            }

            if (Input.GetAxis(verticalAxis) < 0)
            {
                newY--;
            }
            else if (Input.GetAxis(verticalAxis) > 0)
            {
                newY++;
            }

            if (newX != transform.position.x || newY != transform.position.y)
            {
                Debug.Log(newX + ", " + newY);
                inputDelayRemaining = inputDelay;
                transform.position = new Vector3(newX, newY, transform.position.z);
            }

            //TODO: ask the tile manager and only move to a spot if there's actually something there

        }

    }
}
