using UnityEngine;
using System.Collections;
using System;

public class Asteroid : Enemy {
	//function to try to set my cost to 0;
	public void makeFree() {
		mycost=0;
	}
	
	// Use this for initialization
	void Start () {
		mypath = this.GetComponent<Pather>();
		myhealth = 500;
		myspeed = .5f;
		mycost = 10;
	}
	
	// Update is called once per frame
	void Update () {
        checkDead();
        try
        {
            pathMove(this.transform.position, myspeed);
        }
        catch(NullReferenceException)
        { 
            return;
        }
	}
}
