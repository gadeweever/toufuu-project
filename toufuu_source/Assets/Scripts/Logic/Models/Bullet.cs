using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Transform body;
    public float speed;
    //public Path path;

    void Update()
    {
        Move();
    }


    void Move()
    {
        Vector3 positionNew = transform.position + Vector3.up * 10f;
        transform.position = Vector3.Lerp(transform.position, positionNew, speed * Time.deltaTime);
    }
}
