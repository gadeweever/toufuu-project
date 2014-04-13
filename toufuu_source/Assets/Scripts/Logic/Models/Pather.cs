using UnityEngine;
using System.Collections;

public class Pather : MonoBehaviour {

	//array of points make all z's zero
	public Vector3[] points;

    public Vector3 last;

	//counter amongst the array
	public int pos;
	
	//function to adjust path to start position
	public void pathInit(Vector3 me) {
		for (int i = 0 ; i < points.Length ; i++) {points[i]=points[i]+me;}
	}
//	
	//takes the callers position and speed
	public Vector3 getDir(Vector3 me, float speed) {
        if (pos<points.Length && Vector3.Distance(me,points[pos]) >= speed) {
			last=points[pos]-me;
			pos++;
		}
		return last.normalized;
	}
	
	#region Path Maker Functions
	//line path creator
	public void makeLine() {
		Vector3 temp = points[points.Length-1]-points[0];
		points = P_Zero;
		points[0] = temp.normalized;
	}
	
	//arc path creator
	public void makeArc() {
		Vector3[] temp = {points[0],points[points.Length/2],points[points.Length-1]};
		points = P_Zero;
		points[0]=temp[0];
		points[4]=temp[1];
		points[8]=temp[2];
		#region Calculate points
		//calculate the 2 45 degrees off between a and b and select the further one from the other end of the path
		//for point 2
		int a = 0;
		int b = 4;
		Vector3 o1 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(-.5f,.5f,.5f));
		Vector3 o2 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,-.5f,.5f));
		if(Vector3.Distance(o1,points[8])>Vector3.Distance(o2,points[8]))
			{points[2]=o1;}
		else
			{points[2]=o2;}
		//for point 1
		a=0;
		b=2;
		o1 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(-.5f,.5f,.5f));
		o2 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,-.5f,.5f));
		if(Vector3.Distance(o1,points[8])>Vector3.Distance(o2,points[8]))
			{points[1]=o1;}
		else
			{points[1]=o2;}
		//for point 3
		a=2;
		b=4;
		o1 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(-.5f,.5f,.5f));
		o2 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,-.5f,.5f));
		if(Vector3.Distance(o1,points[8])>Vector3.Distance(o2,points[8]))
			{points[3]=o1;}
		else
			{points[3]=o2;}
		//for point 6
		a=4;
		b=8;
		o1 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(-.5f,.5f,.5f));
		o2 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,-.5f,.5f));
		if(Vector3.Distance(o1,points[0])>Vector3.Distance(o2,points[0]))
			{points[6]=o1;}
		else
			{points[6]=o2;}
		//for point 5
		a=4;
		b=6;
		o1 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(-.5f,.5f,.5f));
		o2 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,-.5f,.5f));
		if(Vector3.Distance(o1,points[0])>Vector3.Distance(o2,points[0]))
			{points[5]=o1;}
		else
			{points[5]=o2;}
		//for point 7
		a=6;
		b=8;
		o1 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(-.5f,.5f,.5f));
		o2 = points[a]+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,.5f,.5f))+Vector3.Scale((points[b]-points[a]),new Vector3(.5f,-.5f,.5f));
		if(Vector3.Distance(o1,points[0])>Vector3.Distance(o2,points[0]))
			{points[7]=o1;}
		else
			{points[7]=o2;}
		#endregion
	}
	#endregion
	
	#region Premade Paths
	public Vector3[] P_Up = {Vector3.up};
	public Vector3[] P_Down = {Vector3.down};
	public Vector3[] P_Left = {Vector3.left};
	public Vector3[] P_Right = {Vector3.right};
	public Vector3[] P_Zero = {Vector3.zero};
	#endregion
}
