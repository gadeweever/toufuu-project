using UnityEngine;
using System.Collections;

public class MiniBoss : MonoBehaviour {
	//this is the class for a generic mini boss and all of its functions/vars
	
	#region Variables
	//health of the mini
	public float health;
	
	//the three attack timers and their bools
	//attackxL is the time at last use of the ability
	//attackxR is the bool for being ready
	public Time attack1L; 
	public Time attack2L;
	public Time attack3L;
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
		if (Time.timeSinceLevelLoad - attack1L <=0) {attack1R = true;}
		if (Time.timeSinceLevelLoad - attack2L <=0) {attack2R = true;}
		if (Time.timeSinceLevelLoad - attack3L <=0) {attack3R = true;}
	}
	
	// Use this for initialization
	void Start () {
		//prepair all the attacks
		attack1R = true;
		attack2R = attack3R = false;
		//set distonance between attacks
		attack2L = Time.timeSinceLevelLoad+3.0;
		attack3L = Time.timeSinceLevelLoad+7.0;
	}
	
	// Update is called once per frame
	void Update () {
		//check if i am dead
		if (health <= 0){Destroy(this);}
		
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
