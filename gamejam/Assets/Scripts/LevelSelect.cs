using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour {

    [System.Serializable]
    public struct levelButton
    {
        public GameObject button;
        public string sceneName;
    }

    public levelButton[] levels;

    // Use this for initialization
    void Start () {
		foreach(levelButton lb in levels)
        {
            if(lb.button.GetComponent<Button>()!= null)
                lb.button.GetComponent<Button>().onClick.AddListener(() => TaskOnClick(lb.sceneName));
        }
	}
	
	//Called when button clicked.
	void TaskOnClick (string scenename) {
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
	}
}
