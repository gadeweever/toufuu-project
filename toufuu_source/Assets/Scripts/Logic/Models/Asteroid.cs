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
	
	public void makeFree() {
		mycost=0;
	}
	
	// Use this for initialization
	void Start () {
		mypath = this.GetComponent<Pather>();
		myhealth = 1;
		myspeed = .5f;
		mycost = 10;
	}
	
	// Update is called once per frame
	void Update () {
		//check if i am dead
		if (myhealth<=0){Destroy(this);}
		
		//get and move in new dir
		this.transform.position+=Vector3.Scale(mypath.getDir(this.transform.position, myspeed),new Vector3(myspeed,myspeed,0));
	
		//check cooldown
		//coolCheck();
		
		//attack when ready
		//if (attackR){attack();}
	}
	#endregion
}
