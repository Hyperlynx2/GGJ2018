using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct pipeChoice
{
    public GameObject pipePrefab;
    public int spawnChance;
};

// This is the thing that drives which pipes are available for a player to choose from. You have one of these per player.
public class PipeSelection : MonoBehaviour
{

    // Choose from these: 
    public pipeChoice[]  pipePrefabs;
    public GameObject[] pipeSprites;

    // Picked with the choice1 button, choice2 button, etc. private so you don't edit it in the editor by accident.
    private GameObject[] choice = new GameObject[4];

    public GameObject getChoice(int choiceIndex)
    {
        return choice[choiceIndex];
    }

    public void newChoice(int choiceIndex)
    {
        int totalWeight = 0;
        foreach(pipeChoice p in pipePrefabs)
        {
            totalWeight += p.spawnChance;
        }
        int randomNum = random.Next(0, totalWeight + 1);
        int counter = 0;
        for (int i = 0; i < pipePrefabs.Length; i++)
        {
            counter += pipePrefabs[i].spawnChance;
            if(counter > randomNum)
            {
                choice[choiceIndex] = pipePrefabs[i].pipePrefab;
                break;
            }
        }
        pipeSprites[choiceIndex].GetComponent<Image>().sprite = choice[choiceIndex].gameObject.GetComponent<SpriteRenderer>().sprite;
        pipeSprites[choiceIndex].transform.rotation = choice[choiceIndex].transform.rotation;
    }


    private System.Random random;

    // So that we use the same random selection for both players. 
    private static int s_randomSeed = new System.Random().Next();
   // private static int s_randomSeed = 2; //use a fixed value while debugging.

    // Use this for initialization
    void Start ()
    {
        if (pipePrefabs.Length == 0)
            throw new UnityException("Missing pipe selection prefabs!");

        random = new System.Random(s_randomSeed);

        for (int i = 0; i < 4; i++)
        {
            newChoice(i);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
