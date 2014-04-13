using UnityEngine;
using System.Collections;
using System;

public class Asteroid : Enemy {
	//function to try to set my cost to 0;
	public void makeFree() {
		mycost=0;
	}
    private float rotation;
	// Use this for initialization
	void Start () {
		mypath = this.GetComponent<Pather>();
		myhealth = 500;
		myspeed = .5f;
		mycost = 10;
        rotation = UnityEngine.Random.Range(20, 180);
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
        SlowRotate();
	}

    void SlowRotate()
    {
        if (this.tag == "Asteroid")
            transform.Rotate(0, rotation * Time.deltaTime * .5f, 0);
    }
}
