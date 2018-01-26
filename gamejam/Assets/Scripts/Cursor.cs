using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// One of these per player.
public class Cursor: MonoBehaviour
{
    // Set per player. Used to tell what inputs to get.
    public string leftButton;
    public string rightButton;
    public string upButton;
    public string downButton;
    public string selectPipe1Button;
    public string selectPipe2Button;
    public string selectPipe3Button;
    public string selectPipe4Button;

    private PipeSelection pipeSelection;

    void Start ()
    {
        pipeSelection = GetComponent<PipeSelection>();
        if (pipeSelection == null)
            throw new UnityException("Missing PipeSelection on this object!");
	}
	
	void Update ()
    {        
        float newX = transform.position.x;
        float newY = transform.position.y;

        if (Input.GetButtonDown(leftButton))
        {
            newX--;
        }
        else if (Input.GetButtonDown(rightButton))
        {
            newX++;
        }

        if (Input.GetButtonDown(downButton))
        {
            newY--;
        }
        else if (Input.GetButtonDown(upButton))
        {
            newY++;
        }

        if (newX != transform.position.x || newY != transform.position.y)
        {
            transform.position = new Vector3((float)Math.Round(newX),
                                                (float)Math.Round(newY),
                                                transform.position.z);
        }

        if (Input.GetButtonDown(selectPipe1Button))
        {
            checkAndPlacePipe(0);
        }
        else if (Input.GetButtonDown(selectPipe2Button))
        {
            checkAndPlacePipe(1);
        }
        else if (Input.GetButtonDown(selectPipe3Button))
        {
            checkAndPlacePipe(2);
        }
        else if (Input.GetButtonDown(selectPipe4Button))
        {
            checkAndPlacePipe(3);
        }

        //TODO: ask the tile manager and only move to a spot if there's actually something there

    }

    // If the current position isn't occupied, place this pipe in the current location and generate
    // a new choice.
    private void checkAndPlacePipe(int pipeChoiceIndex)
    {
        TileManager tileManager = GameObject.FindObjectOfType<TileManager>();
        if (tileManager.isEmpty(transform.position))
        {
            GameObject newPipe = Instantiate(pipeSelection.getChoice(pipeChoiceIndex));
            newPipe.transform.position = transform.position;

            pipeSelection.newChoice(pipeChoiceIndex);
        }
    }

}

