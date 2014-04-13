using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    #region Variables
    float attackC, attackL;
    bool attackR;
    #endregion

    #region functions
    //attack\
    void attack()
    {
        if (attackR)
        {
            //commenceattack
            attackL = Time.timeSinceLevelLoad;
            attackR = false;
        }
    }
    //cooldown checker
    void coolCheck()
    {
        if (Time.timeSinceLevelLoad - attackL >= attackC) { attackR = true; }
    }

    // Use this for initialization
	void Start () {
        attackR = true;
        attackL = Time.timeSinceLevelLoad;
	}

    //update
    void Update()
    {
        coolCheck();
    }
    #endregion
}
