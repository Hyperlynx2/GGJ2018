using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public GameObject Player1Water;
    public GameObject Player2Water;

    private float playerOneScore;
    private float playerTwoScore;

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

    }
	
	// Update is called once per frame
	void Update () {
		
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

}
