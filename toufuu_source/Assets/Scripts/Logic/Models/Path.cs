using UnityEngine;
using System.Collections;

public class Path : MonoBehavior {

	//array of points make all z's zero
	public Vector3[] points;
	
	public Vector3 last;
	
	//counter amongst the array
	public int pos;
	
	public Vector3 getDir(Vector3 me, float speed) {
		if (Vector3.Distance(me,points[pos]) < speed && pos!=points.length) {last=Vector3.Angle(me,points[pos]);}
		return last;
	}	
}