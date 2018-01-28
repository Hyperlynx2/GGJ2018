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
    public string horizontalAxis;
    public string verticalAxis;
    public float inputDelayTime;

    private float stickDelayX;   //Variable used to ensure joystick inputs don't scroll crazy fast
    private float stickDelayY;

    private AudioManager audioManager;

    private PipeSelection m_pipeSelection;
    private TileManager m_tileManager;

    void Start ()
    {
        stickDelayX = 0;
        stickDelayY = 0;

        audioManager = FindObjectOfType<AudioManager>();

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

        stickDelayX -= Time.deltaTime;
        stickDelayY -= Time.deltaTime;

        //Axis Inputs
        //Horizontal movement
        if (Input.GetButtonDown(leftButton))
        {
            newX--;
        }
        else if (Input.GetButtonDown(rightButton))
        {
            newX++;
        }
        else if (stickDelayX <= 0)
        {
            if (Input.GetAxis(horizontalAxis) > 0)
            {
                newX++;
                stickDelayX = inputDelayTime;
            }
            else if (Input.GetAxis(horizontalAxis) < 0)
            {
                newX--;
                stickDelayX = inputDelayTime;
            }
        }

        if (Input.GetButtonDown(downButton))
        {
            newY--;
        }
        else if (Input.GetButtonDown(upButton))
        {
            newY++;
        }
        else if (stickDelayY <= 0)
        { 
            //Vertical movement
            if (Input.GetAxis(verticalAxis) > 0)
            {
                newY++;
                stickDelayY = inputDelayTime;
            }
            else if (Input.GetAxis(verticalAxis) < 0)
            {
                newY--;
                stickDelayY = inputDelayTime;
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


            //USE THIS FOR PLACE PIPE SOUND EFFECT

           // audioManager.playOnce(placePipe);

            m_pipeSelection.newChoice(pipeChoiceIndex);
        }
    }

}

