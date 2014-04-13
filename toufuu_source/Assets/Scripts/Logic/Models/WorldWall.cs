using UnityEngine;
using System.Collections;

public class WorldWall : MonoBehaviour
{
    void onCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "player": 
                break;
            case "enemy": other.gameObject.GetComponent<Enemy>().suicide();
                break;
            case "bullet": Destroy(other.gameObject);
                break;
        }
    }
}