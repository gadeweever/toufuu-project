using UnityEngine;
using System.Collections;

public class Pather : MonoBehaviour
{

    //array of points make all z's zero
    public Vector3[] points;
    public Vector3[] temp;

    public Vector3 last;

    //counter amongst the array
    public int pos;

    //function to adjust path to start position
    public void pathInit(Vector3 me)
    {
        Vector3[] temp = new Vector3[points.Length];
        temp[0] = me;
        for (int i = 1; i < points.Length; i++) { temp[i] = points[i] - points[i - 1] + temp[i - 1]; }
        points = temp;
    }

    //function to add wall for first part of a path, to be called after pathInit
    public Vector3 spawnAtWall()
    {
        if (points.Length > 1)
        {
            Vector3[] tempr = new Vector3[points.Length + 1];
            tempr[0] = traceToWall(points[0], points[1]);
            for (int i = 0; i < points.Length; i++)
                tempr[i+1] = points[i];
            points = tempr;
        }

        return points[0];
    }

    //function to find the nearest wall
    public Vector3[] toTheWindows(Vector3 me, Vector3[] pp)
    {
        Vector3 rev = me - pp[0];
        rev = Vector3.Scale(rev.normalized, new Vector3(.5f, .5f, .5f));
        Vector3 r = me;
        while (!(-.2f < r.x && r.x < .2f) || !(1919.8f < r.x && r.x < 1920.2f) || !(-.2f < r.y && r.y < .2f) || !(1279.8f < r.y && r.y < 1980.2f))
        {
            r += rev;
        }
        Vector3[] temp = new Vector3[pp.Length + 1];
        for (int i = 0; i < pp.Length; i++) { temp[i + 1] = pp[i]; }
        temp[0] = r;
        return temp;
    }

    //function to trace straight paths back to wall
    public Vector3 traceToWall(Vector3 start, Vector3 end)
    {
        //left x=0; right x= 400
        //bottom y=0; top y = 200
        bool found = false;
        Vector3 wpos = start;
        int escape = 0;
        while (!found)
        {
            if (escape > 800)
            {
                Debug.Log("forced to escape");
                return (new Vector3(200, 200, 0));
            }
            if (wpos.x < 0 || wpos.x > 400 || wpos.y < 0 || wpos.y > 200)
                found = true;
            else
            {
                escape++;
                wpos = wpos + (start - end).normalized;
            }
        }
        return wpos;
    }


    #region Path Maker Functions
    //line path creator
    public void makeLine()
    {
        temp = new Vector3[3];
        temp[0]=points[0];
        temp[1] = points[points.Length - 1];
        temp[2] = (temp[1] - temp[0]) * 1000f;
        points = new Vector3[3];
        points[0] = temp[0];
        points[1] = temp[1];
        points[2] = temp[2];
    }

    //arc path creator
    public void makeArc()
    {
        Vector3[] temp = { points[0], points[points.Length / 2], points[points.Length - 1] };
        points = P_Zero;
        points[0] = temp[0];
        points[4] = temp[1];
        points[8] = temp[2];
        #region Calculate points
        //calculate the 2 45 degrees off between a and b and select the further one from the other end of the path
        //for point 2
        int a = 0;
        int b = 4;
        Vector3 o1 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(-.5f, .5f, .5f));
        Vector3 o2 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, -.5f, .5f));
        if (Vector3.Distance(o1, points[8]) > Vector3.Distance(o2, points[8]))
        { points[2] = o1; }
        else
        { points[2] = o2; }
        //for point 1
        a = 0;
        b = 2;
        o1 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(-.5f, .5f, .5f));
        o2 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, -.5f, .5f));
        if (Vector3.Distance(o1, points[8]) > Vector3.Distance(o2, points[8]))
        { points[1] = o1; }
        else
        { points[1] = o2; }
        //for point 3
        a = 2;
        b = 4;
        o1 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(-.5f, .5f, .5f));
        o2 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, -.5f, .5f));
        if (Vector3.Distance(o1, points[8]) > Vector3.Distance(o2, points[8]))
        { points[3] = o1; }
        else
        { points[3] = o2; }
        //for point 6
        a = 4;
        b = 8;
        o1 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(-.5f, .5f, .5f));
        o2 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, -.5f, .5f));
        if (Vector3.Distance(o1, points[0]) > Vector3.Distance(o2, points[0]))
        { points[6] = o1; }
        else
        { points[6] = o2; }
        //for point 5
        a = 4;
        b = 6;
        o1 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(-.5f, .5f, .5f));
        o2 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, -.5f, .5f));
        if (Vector3.Distance(o1, points[0]) > Vector3.Distance(o2, points[0]))
        { points[5] = o1; }
        else
        { points[5] = o2; }
        //for point 7
        a = 6;
        b = 8;
        o1 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(-.5f, .5f, .5f));
        o2 = points[a] + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, .5f, .5f)) + Vector3.Scale((points[b] - points[a]), new Vector3(.5f, -.5f, .5f));
        if (Vector3.Distance(o1, points[0]) > Vector3.Distance(o2, points[0]))
        { points[7] = o1; }
        else
        { points[7] = o2; }
        #endregion
    }
    #endregion

    #region Premade Paths
    public Vector3[] P_Up = { Vector3.up };
    public Vector3[] P_Down = { Vector3.down };
    public Vector3[] P_Left = { Vector3.left };
    public Vector3[] P_Right = { Vector3.right };
    public Vector3[] P_Zero = { Vector3.zero };
    #endregion
}
