using UnityEngine;
using System.Collections;

public class EHomingBullet : Bullet
{
    public Transform target;

    void Start() { target = null; }

    void Move()
    {
        if (target != null)
        {
            Vector3 nextmove = Vector3.RotateTowards(this.transform.position, target.position, 5f, speed);
            this.transform.position += Vector3.Scale(nextmove, new Vector3(speed, speed, speed));
        }
    }
}