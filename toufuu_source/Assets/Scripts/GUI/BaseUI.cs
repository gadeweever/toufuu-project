using UnityEngine;
using System.Collections;

public class BaseUI : MonoBehaviour {

    public GameState gamestate;
	// Use this for initialization
	void Start () {
        gamestate = GetComponent<GameState>();
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
        GUI.Box(new Rect(Screen.width / 2, 50, 100, 30), (gamestate.totalTime - Time.timeSinceLevelLoad).ToString());
    }
}
