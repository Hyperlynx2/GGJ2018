using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private int playerOneScore;
    private int playerTwoScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Increments the score by passing a bool to indicate whether the score is for player one.
    public void incrementScore(bool isPlayerOne)
    {
        if(isPlayerOne)
        {
            playerOneScore++;
            Debug.Log("Player One Wins!!");
        }
        else
        {
            playerTwoScore++;
            Debug.Log("Player Two Wins!!");
        }
    }

}
