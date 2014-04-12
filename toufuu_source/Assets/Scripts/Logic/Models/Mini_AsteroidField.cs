using UnityEngine;
using System.Collections;

public class Mini_AsteroidField : MiniBoss {
	//all uses of 100 in this code is assuming the field goes from 0-100, change it and delet this comment
	//the known range of the field is found
	
	public Transform asteroid;
	
	public Pather pather;
	
	//spawns from above going down
	new public void attack1() {
		Transform na = Object.Instantiate(asteroid, new Vector3(Random.Range(0,100),100,0), Quaternion.identity) as Transform;
		Pather nan = na.gameObject.GetComponent<Pather>();
		nan.points = new Vector3[] {Vector3.Scale(Vector3.down,new Vector3(6,6,6))};
		nan.pathInit(na.transform.position);
		na.gameObject.GetComponent<Asteroid>().makeFree();
	}
	//spawns from bottom right going up left
	new public void attack2() {
		Transform na = Object.Instantiate(asteroid, new Vector3(50+Random.Range(0,100),0,0), Quaternion.identity) as Transform;
		Pather nan = na.gameObject.GetComponent<Pather>();
		nan.points = new Vector3[] {Vector3.Scale(new Vector3(6,6,6),new Vector3(-1,1,0))};
		nan.pathInit(na.transform.position);
		na.gameObject.GetComponent<Asteroid>().makeFree();
	}
	
	//spawns from bottom left going up right
	new public void attack3() {
		Transform na = Object.Instantiate(asteroid, new Vector3(Random.Range(0,100)-50,0,0), Quaternion.identity) as Transform;
		Pather nan = na.gameObject.GetComponent<Pather>();
		nan.points = new Vector3[] {Vector3.Scale(new Vector3(6,6,6),new Vector3(1,1,0))};
		nan.pathInit(na.transform.position);
		na.gameObject.GetComponent<Asteroid>().makeFree();
	}
	
	public void Start() {
		pather = GetComponent<Pather>();
		mypath = pather;
		myhealth = 600f;
		mypath.points = pather.P_Zero;
		myspeed = 0;
		mycost = 100;
		attack1C = attack2C = attack3C = .3f;
		attack1R = true;
		attack2R = attack3R = false;
		attack1L = attack2L = attack3L = Time.timeSinceLevelLoad;
		attack2L+=.1f;
		attack3L+=.2f;
	}
	
	public void Update () {
		if (myhealth <= 0) {
			//increase all player scores
			//refund cost
			Destroy(this);
		}
		myhealth--;
		
		coolCheck();
		
		if(attack1R){attack1();}
		if(attack2R){attack2();}
		if(attack3R){attack3();}
	}
}
