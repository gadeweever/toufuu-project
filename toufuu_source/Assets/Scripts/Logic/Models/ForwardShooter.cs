﻿using UnityEngine;
using System.Collections;

public class ForwardShooter : Enemy
{
    public Transform bullet;
    public void attack()
    {
        Transform nb = Object.Instantiate(bullet, this.transform.position, Quaternion.identity) as Transform;
        nb.gameObject.GetComponent<Pather>().points = mypath.points;
        nb.gameObject.GetComponent<Pather>().pathInit(nb.position);
    }

    void Start()
    {
        myhealth = 5;
        mycost = 10;
        myspeed = 1;
        mypath = this.GetComponent<Pather>();
        attackC = 1;
        attackL = Time.timeSinceLevelLoad;
        attackR = true;
    }

    void Update()
    {
        //if (coolCheck())
            attack();
    }
}