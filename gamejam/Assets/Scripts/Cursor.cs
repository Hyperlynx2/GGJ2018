﻿using System.Collections;
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
    public float inputDelayTime;

    private float inputDelayX;   //Variable used to ensure joystick inputs don't scroll crazy fast
    private float inputDelayY;

    private PipeSelection m_pipeSelection;
    private TileManager m_tileManager;

    void Start ()
    {
        inputDelayX = 0;
        inputDelayY = 0;

        m_pipeSelection = GetComponent<PipeSelection>();
        if (m_pipeSelection == null)
            throw new UnityException("Missing PipeSelection on this object!");

        m_tileManager =  GameObject.FindObjectOfType<TileManager>();
        if(m_tileManager == null)
            throw new UnityException("Missing TileManager!");
    }
	
	void Update ()
    {        
        float newX = transform.position.x;
        float newY = transform.position.y;

        inputDelayX -= Time.deltaTime;
        inputDelayY -= Time.deltaTime;

        //Button Inputs
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

        //Axis Inputs
        //Horizontal movement
        if (inputDelayX <= 0)
        {
            if (Input.GetAxis("Player1Horizontal") > 0)
            {
                newX++;
                inputDelayX = inputDelayTime;
            }
            else if (Input.GetAxis("Player1Horizontal") < 0)
            {
                newX--;
                inputDelayX = inputDelayTime;
            }
        }
        if(inputDelayY <= 0)
        { 
            //Vertical movement
            if (Input.GetAxis("Player1Vertical") > 0)
            {
                newY++;
                inputDelayY = inputDelayTime;
            }
            else if (Input.GetAxis("Player1Vertical") < 0)
            {
                newY--;
                inputDelayY = inputDelayTime;
            }
        }

        if (m_tileManager.isTileInPlay(newX, newY)
        && (newX != transform.position.x || newY != transform.position.y))
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
        if (m_tileManager.isEmpty(transform.position))
        {
            GameObject newPipe = Instantiate(m_pipeSelection.getChoice(pipeChoiceIndex));
            if (newPipe == null)
                throw new UnityException("Missing pipe prefab for choice " + pipeChoiceIndex);

            newPipe.transform.position = transform.position;

            m_pipeSelection.newChoice(pipeChoiceIndex);
        }
    }

}

