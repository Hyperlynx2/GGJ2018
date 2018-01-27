using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class FillAreaWithObject : ScriptableWizard {

    public Collider2D area;
    public GameObject prefab;

    [MenuItem("My Tools/Fill Area with Object")]
    static void SnapToGridWizard()
    {
        ScriptableWizard.DisplayWizard<FillAreaWithObject>("Fill Area with Object", "Fill");

    }

    void OnWizardCreate()
    {
        int minX = (int)Mathf.Round(area.GetComponent<Collider2D>().bounds.min.x);
        int maxX = (int)Mathf.Round(area.GetComponent<Collider2D>().bounds.max.x);
        int minY = (int)Mathf.Round(area.GetComponent<Collider2D>().bounds.min.y);
        int maxY = (int)Mathf.Round(area.GetComponent<Collider2D>().bounds.max.y);

        for (int x = minX; x <= maxX; x++)
        {
            for(int y = minY; y <= maxY; y++)
            {
                GameObject go = PrefabUtility.InstantiatePrefab(prefab, SceneManager.GetActiveScene()) as GameObject;
                go.transform.position = new Vector3(x, y, 0);
            }
        }

    }


}
