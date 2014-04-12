using UnityEngine;
using System.Collections;

public class BaseUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        DrawTime();
    }

    void DrawTime()
    {
        GUI.Box(new Rect(Screen.width / 2, 50, 100, 30), Time.timeSinceLevelLoad.ToString());
    }
}
