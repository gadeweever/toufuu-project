using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour
{


    //self-explanatory variable identities
    public int current, max, rate;
    // Use this for initialization
    void Start()
    {
        current = 50;
        max = 140;
        rate = 65;
    }

    // Update is called once per frame
    void Update()
    {
        Replenish();
    }

    // uses the rate to reinstantiate the toolbar energy
    void Replenish()
    {
        if (current < max)
            current += (int)(rate * Time.deltaTime);
    }

    void Kill()
    {

    }
}
