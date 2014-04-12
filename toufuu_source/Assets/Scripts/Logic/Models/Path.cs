using UnityEngine;
using System.Collections;

public class Pather : MonoBehaviour {

	//array of points make all z's zero
	public Vector3[] points;
	
	public Vector3 last;
	
	//counter amongst the array
	public int pos;
	
    ////function to adjust path to start position
    //public void pathInit(Vector3 me) {
    //    for (int i = 0 ; i < points.Length ; i++)
    //    //{points[i]=Vector3.add(points[i],me);}
    //}
	
    ////takes the callers position and speed
    //public Vector3 getDir(Vector3 me, float speed) {
    //    //if (Vector3.Distance(me,points[pos]) < speed && pos!=points.length) {last=Vector3.Angle(me,points[pos]);}
    //    //return last;
    //}	
}