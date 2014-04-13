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

    //cost
    public int mycost;
	
	//attack vars: R=ready L=last C=cooldown
	public bool attackR;
	public float attackL;
	public float attackC;
	#endregion
	
	#region Functions
	//function to handle attacking
	public void attack(){}
	
	public void coolCheck() {
		if(Time.timeSinceLevelLoad - attackL >= attackC) {attackR=true;}
	}
	
	// Use this for initialization
	void Start () {
		mypath = GetComponent<Pather>();
		//init path
		mypath.pathInit(this.transform.position);
		
		//start attack
		attackR=true;
	}

    //check if i am dead
    public void checkDead() { if (myhealth <= 0) { suicide(); } }

    //follow path
    public void pathMove(Vector3 me, float speed)
    {
        if (mypath.pos < mypath.points.Length) { this.transform.position = Vector3.MoveTowards(me, (mypath.points[mypath.pos]), myspeed); }
        if (mypath.pos < mypath.points.Length && Vector3.Distance(me, mypath.points[mypath.pos]) < .2f) { mypath.pos++; }
    }

	// Update is called once per frame
	void Update () {
        checkDead();
        pathMove(this.transform.position, myspeed);
		coolCheck();
		if (attackR){attack();}
	}

    //last commands before destroying
    public void suicide()
    {
        Destroy(this);
    }
	#endregion
}
