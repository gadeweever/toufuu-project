using UnityEngine;
using System.Collections;

public class FowardHomerEnemy : Enemy
{
    public Transform bullet;
    new public void attack()
    {
        
        Transform nb = Object.Instantiate(bullet, this.transform.position, Quaternion.identity) as Transform;
        GameObject[] plays = GameObject.FindGameObjectsWithTag("player");
        nb.gameObject.GetComponent<EHomingBullet>().target = plays[(Random.Range(0, plays.Length - 1))].transform;
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
}