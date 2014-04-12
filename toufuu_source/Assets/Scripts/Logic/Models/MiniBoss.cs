using UnityEngine;
using System.Collections;

public class MiniBoss : MonoBehavior {
	//this is the class for a generic mini boss and all of its functions/vars
	
	#region Variables
	//health of the mini
	public int health;
	
	//the three attack timers and start times
	//attackx_t is the current timer till next attack
	//attackx_s is the start of the timer after attack
	public int attack1_t; 
	public int attack2_t;
	public int attack3_t;
	public int attack1_s;
	public int attack2_s;
	public int attack3_s;
	
	//the movement path of the mini
	public Path mypath;
	#endregion
	
	#region Functions
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	#endregion
}
