using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
    // checks whether we are dealing with Time mode or Persona
	public bool isTime;
    // variable comparison against timeSinceLevelLoad. it is in seconds
    public float totalTime;
	
	// Use this for initialization
	void Start () {
		isTime = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
