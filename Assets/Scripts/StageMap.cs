using UnityEngine;
using System.Collections;

public class StageMap : MonoBehaviour {

    public StageSelector selectorReference;

    static float size = 200.0f;
    Vector3[] positions = new Vector3[9] {
        new Vector3(-size,  size, 0),
        new Vector3(    0,  size, 0),
        new Vector3( size,  size, 0),
        new Vector3(-size,     0, 0),
        new Vector3(    0,     0, 0),
        new Vector3( size,     0, 0),
        new Vector3(-size, -size, 0),
        new Vector3(    0, -size, 0),
        new Vector3( size, -size, 0)
    };
	// Use this for initialization
	void Awake () {
        Debug.Log("setting selectors for " + ProgressManager.levelMap.Length + " stages...");
        for (int i = 0; i < ProgressManager.levelMap.Length; i++) {
            Debug.Log("stage selector " + (i + 1));
            StageSelector sel = Instantiate(selectorReference, positions[i], Quaternion.identity) as StageSelector;
            Debug.Log("selector ID: " + sel.GetInstanceID());
            sel._stageNumber = (i + 1);
            Debug.Log("selector Stage: " + sel._stageNumber);
            sel.transform.parent = transform;
            sel.enabled = true;
            sel.gameObject.SetActive(true);
            sel.gameObject.layer = gameObject.layer;
        }
        Debug.Log("setting selectors complete");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
