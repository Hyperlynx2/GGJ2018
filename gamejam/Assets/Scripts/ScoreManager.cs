using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    enum GameState
    {
        countdown, gameInProgress, tallyingScores, gameOver
    }

    public GameObject Player1Water;
    public GameObject Player2Water;

    private TileManager tileManager;
    private Countdown countdown;

    public GameObject p1Cursor;
    public GameObject p2Cursor;

    public GameObject p1ScoreText;
    public GameObject p2ScoreText;

    private float playerOneScore;
    private float playerTwoScore;
    private float lostWater;
    public float MAXSCORE;
    private int displayScorep1;
    private int displayScorep2;

    private GameState gameState;
    private float p1StartY;
    private RectTransform p1WaterTransform;
    private float p2StartY;
    private RectTransform p2WaterTransform;

    // Use this for initialization
    void Start () {
        p1StartY = Player1Water.GetComponent<RectTransform>().position.y;
        p1WaterTransform = Player1Water.GetComponent<RectTransform>();
        p2StartY = Player2Water.GetComponent<RectTransform>().position.y;
        p2WaterTransform = Player2Water.GetComponent<RectTransform>();
        lostWater = 0;
        gameState = GameState.countdown;
        countdown = FindObjectOfType<Countdown>();
        tileManager = FindObjectOfType<TileManager>();
        if(tileManager == null)
        {
            throw new UnityException("Tile manager missing");
        }

    }
	
	// Update is called once per frame
	void Update () {

        switch(gameState)
        {
            case GameState.countdown:
                if (!countdown.stillCounting())
                {
                    gameState = GameState.gameInProgress;
                }
                break;
            case GameState.gameInProgress:
                if(!tileManager.stillFlowing())
                {
                    gameState = GameState.tallyingScores;
                }
                break;
            case GameState.tallyingScores:
                tallyScores();
                break;
            case GameState.gameOver:
                //Who wins???
                break;
        }   
	}

    //Increments the score by passing a bool to indicate whether the score is for player one.
    public void incrementScore(bool isPlayerOne, float scoreIncrement)
    {
        if(isPlayerOne)
        {
            playerOneScore += scoreIncrement;
            p1WaterTransform.localScale = new Vector3(1, 400.0f * playerOneScore / 5.0f, 1);
            p1WaterTransform.position = new Vector3(p1WaterTransform.position.x, p1StartY + p1WaterTransform.lossyScale.y/2, 0);
            
        }
        else
        {
            playerTwoScore += scoreIncrement;
            p2WaterTransform.localScale = new Vector3(1, 400.0f * playerTwoScore / 5.0f, 1);
            p2WaterTransform.position = new Vector3(p2WaterTransform.position.x, p2StartY + p2WaterTransform.lossyScale.y / 2, 0);
        }
    }

    public void addLostWater(float waterLost)
    {
        lostWater += waterLost;
    }

    private void tallyScores()
    {
        //Stop the game
        p1Cursor.SetActive(false);
        p2Cursor.SetActive(false);
        p1ScoreText.SetActive(true);
        p2ScoreText.SetActive(true);

        //Calculate scores by draining the water
        if (playerTwoScore > 0)
        {
            playerTwoScore -= 0.005f;
            p2WaterTransform.localScale = new Vector3(1, 400.0f * playerTwoScore / 5.0f, 1);
            p2WaterTransform.position = new Vector3(p2WaterTransform.position.x, p2StartY + p2WaterTransform.lossyScale.y / 2, 0);
            displayScorep2 += 1;
            p2ScoreText.GetComponent<Text>().text = displayScorep1.ToString();
        }
        if (playerOneScore > 0)
        {
            playerOneScore -= 0.005f;
            p1WaterTransform.localScale = new Vector3(1, 400.0f * playerOneScore / 5.0f, 1);
            p1WaterTransform.position = new Vector3(p1WaterTransform.position.x, p1StartY + p1WaterTransform.lossyScale.y / 2, 0);
            displayScorep1 += 1;
            p1ScoreText.GetComponent<Text>().text = displayScorep1.ToString();
        }
        if (playerOneScore <= 0 && playerTwoScore <= 0)
        {
            gameState = GameState.gameOver;
        }       
    }

    private void calculateWinner()
    {
        if(displayScorep1 > displayScorep2)
        {
            //p1 wins
        }
        else if (displayScorep2 > displayScorep1)
        {
            //p2 wins
        }
        else
        {
            //Draw
        }
    }

}
