using System.Collections;
using UnityEngine;
using UnityEditor;

public class SnapToGrid : ScriptableWizard {

	[MenuItem ("My Tools/Snap To Grid")]
    static void SnapToGridWizard()
    {
        ScriptableWizard.DisplayWizard<SnapToGrid>("Snap To Grid", "Snap");

    }

    void OnWizardCreate()
    {
        GameObject[] go = GameObject.FindObjectsOfType<GameObject>();
        foreach(GameObject g in go)
        {
            if (g.layer == LayerMask.NameToLayer("Tiles"))
            {
                g.transform.position = new Vector3(Mathf.Round(g.transform.position.x), Mathf.Round(g.transform.position.y), 0);
            }         
        }
    }
}
