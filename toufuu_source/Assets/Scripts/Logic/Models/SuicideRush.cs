using UnityEngine;
using System.Collections;

public class SuicideRush : Enemy
{
    void Start ()
    {
        //set all vars
        myhealth = 1;
        myspeed = 5;
        mycost = 5;
        mypath = this.GetComponent<Pather>();
    }

    void Update()
    {
        checkDead();
        pathMove(this.transform.position, myspeed);
    }
}