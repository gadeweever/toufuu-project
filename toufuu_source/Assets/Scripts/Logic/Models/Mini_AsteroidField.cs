using UnityEngine;
using System.Collections;

public class Mini_AsteroidField : MiniBoss {
	//all uses of 100 in this code is assuming the field goes from 0-100, change it and delet this comment
	//the known range of the field is found
	//spawns from above going down
	new public void attack1() {
		GameObject E_Asteroid = GameObject.Find("E_Asteroid");
		Enemy na = (Enemy) Object.Instantiate(E_Asteroid, new Vector3(Random.Range(0,100),100,0), Quaternion.identity);
		na.mypath.points = mypath.P_Down;
		na.mycost = 0;
	}
	//spawns from bottom right going up left
	new public void attack2() {
		GameObject E_Asteroid = GameObject.Find("E_Asteroid");
		Enemy na = (Enemy) Object.Instantiate(E_Asteroid, new Vector3(50+Random.Range(0,100),0,0), Quaternion.identity);
		na.mypath.points[0] = new Vector3(-1,1,0);
		na.mycost = 0;
	}
	
	//spawns from bottom left going up right
	new public void attack3() {
		GameObject E_Asteroid = GameObject.Find("E_Asteroid");
		Enemy na = (Enemy) Object.Instantiate(E_Asteroid, new Vector3(Random.Range(0,100)-50,0,0), Quaternion.identity);
		na.mypath.points[0] = new Vector3(1,1,0);
		na.mycost = 0;
	}
	
	public void Start() {
		myhealth = 600f;
		mypath.points = mypath.P_Zero;
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
