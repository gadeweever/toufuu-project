using UnityEngine;
using System.Collections;

public class MiniBoss : MonoBehaviour {
	//this is the class for a generic mini boss and all of its functions/vars
	
	#region Variables
	//health of the mini
	public float myhealth;
	
	//speed
	public float myspeed;
	
	//cost
	public float mycost;
	
	//the three attack timers and their bools:L = last C = cooldown R = ready
	public float attack1L; 
	public float attack2L;
	public float attack3L;
	public float attack1C; 
	public float attack2C;
	public float attack3C;
	public bool attack1R;
	public bool attack2R;
	public bool attack3R;
	
	//the movement path of the mini
	public Pather mypath;
	#endregion
	
	#region Functions
	
	//void functions to execute the attacks to be overwriten by children
	#region Attacks
	public void attack1(){}
	public void attack2(){}
	public void attack3(){}
	#endregion
	
	//check cooldowns
	public void coolCheck() {
		if (Time.timeSinceLevelLoad - attack1L >=attack1C) {attack1R = true;}
		if (Time.timeSinceLevelLoad - attack2L >=attack2C) {attack2R = true;}
        if (Time.timeSinceLevelLoad - attack3L >= attack3C) { attack3R = true; }

	}
	
	// Use this for initialization
	void Start () {
		//prepair all the attacks
		attack1R = true;
		attack2R = attack3R = false;
		//set distonance between attacks
		attack2L = Time.timeSinceLevelLoad+3.0f;
		attack3L = Time.timeSinceLevelLoad+7.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//check if i am dead
		if (myhealth <= 0){Destroy(this);}
		
		//update attack bools
		coolCheck();
		
		//if an attack is ready launch it
		if (attack1R) {attack1 ();}
		if (attack2R) {attack2 ();}
		if (attack3R) {attack3 ();}
		
		//somehow move on the path idk
	}
	#endregion
}
