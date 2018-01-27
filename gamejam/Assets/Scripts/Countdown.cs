using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public int countdownTime;

    private float timer;
    private float nextTime;
    private bool counting;

	// Use this for initialization
	void Start () {

        this.GetComponent<Text>().text = countdownTime.ToString();
        timer = countdownTime;
        nextTime = timer-1;
        counting = true;

	}
	


	// Update is called once per frame
	void Update () {

        if(counting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                this.GetComponent<Text>().text = "Start!";
                nextTime--;
            }
            if (timer <= -1)
            {
                counting = false;
            }
            if (timer <= nextTime)
            {
                nextTime--;
                this.transform.localScale = new Vector3(1, 1, 1);
                this.GetComponent<Text>().text = (nextTime + 1).ToString();
            }
            else
            {
                this.transform.localScale = new Vector3(2 - (timer - nextTime), 2 - (timer - nextTime), 1);
                this.GetComponent<Text>().color = new Color(1, 0, 0, timer - nextTime);
            }
        }

	}
}
