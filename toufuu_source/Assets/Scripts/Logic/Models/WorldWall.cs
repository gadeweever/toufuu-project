using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    void onCollisionEnter(Collision other)
    {
        switch (other.gameObject.GetType().ToString())
        {
            case "Player": 
                break;
            case "Enemy": other.gameObject.GetComponent<Enemy>().suicide();
                break;
            case "Bullet": Destroy(other.gameObject);
                break;
        }
    }
}