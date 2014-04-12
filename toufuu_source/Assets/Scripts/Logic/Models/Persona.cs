using UnityEngine;
using System.Collections;

public class Persona : MonoBehaviour {
	/* This class contains no constructor, but methods for setting values at the beginning of the game.
	 * the reason for this is that there should only be maximum ONE Persona at any time, therefore
	 * this class is reusable */
	
	#region Persona Qualities
	// represents the current energy a persona has to instantiate minions
	// this should be depleted using a time function, or with the available other functions
	public int energy;
	
	// currentEnemyCount: enemies currently instantiated
	public int currentEnemyCount;
	
	// maxQueue: max number of queueable minions to instantiate
	public int maxQueue;
	
	//list of enemies currently on the field
	public Enemy[] currents;
	
	//list of specific enemy units
	public Enemy[] special_units;
	
	//list of specificInstanced mini bosses;
	public MiniBoss[] special_mini_boss;
	
	//array of available units;
	public Enemy[] units;
	
	//array of available mini bosses
	public MiniBoss[] miniBosses;
	#endregion
	
	#region Extra Class Variables
	// timeConstant: Multiplier used to speed up or slow down depletion of energy
	// provides easy acess in GUI for testing different values until a constant decision is made
	private float timeConstant;
	#endregion
	
	public void ability1(){}
	public void ability2(){}
	
	private int counter;
	private int pos;
	public bool makingPath;
	public Pather lastPath;
	
	public void Start() {
		counter=0;
		pos=0;
	}
	
	public void Update() {
		#region freeform path creation
		if (Input.GetMouseButtonDown(0)&&makingPath) {
			lastPath.points=lastPath.P_Zero;
		}
		if (Input.GetMouseButton(0)&&makingPath) {
			counter++;
			if (counter>=30) {
				lastPath.points[pos]=Input.mousePosition;
				counter=0;
				pos++;
			}
		}
		if (Input.GetMouseButtonUp(0)&&makingPath) {
			counter=0;
			pos=0;
			makingPath=false;
		}
		#endregion
	}

	public void TimeDeplete()
	{
	}
}
