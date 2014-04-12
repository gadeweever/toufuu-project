using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	#region Variables
	//mypath
	public Pather mypath;
	
	//health
	public float myhealth;
	
	//speed
	public float myspeed;
	
	//attack vars: R=ready L=last
	public bool attackR;
	public float attackL;
	#endregion
	
	#region Functions
	//function to handle attacking
	public void attack(){}
	
	// Use this for initialization
	void Start () {
		//init path
		mypath.pathInit(this.transform.position);
		
		//start attack
		attackR=true;
	}
	
	// Update is called once per frame
	void Update () {
		//check if i am dead
		if (myhealth<=0){Destroy(this);}
		
		//get and move in new dir
		mypath.getDir(this.transform.position, myspeed);
		
		//attack when ready
		if (attackR){attack();}
	}
	#endregion
}
