using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Transform body;
    public float speed;
    //public Path path;

    void onCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "enemy": other.gameObject.GetComponent<Enemy>().suicide();
                break;
        }
        Destroy(this);
    }

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
