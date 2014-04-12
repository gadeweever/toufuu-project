using UnityEngine;
using System.Collections;

public class Asteroid : Enemy {
	
	
	#region Variables
	/* the following variables are inherited from Enemy
	//mypath
	public Pather mypath;
	
	//health
	public float myhealth;
	
	//speed
	public float myspeed;
	
	//attack vars: R=ready L=last C=cooldown
	public bool attackR;
	public float attackL;
	public float attackC;
	*/
	#endregion
	
	#region Functions
	//function to handle attacking
	/* not needed, cuz asteroid
	public void attack(){
		
	}
	*/
	
	/* also not needed
	public void coolCheck() {
		if(Time.timeSinceLevelLoad - attackL >= attackC) {attackR=true;}
	}
	*/
	
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
	
		//check cooldown
		//coolCheck();
		
		//attack when ready
		//if (attackR){attack();}
	}
	#endregion
}
