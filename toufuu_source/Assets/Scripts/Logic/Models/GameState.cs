using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{

    // checks whether we are dealing with Time mode or Persona
    public bool isTime;
    // variable comparison against timeSinceLevelLoad. it is in seconds
    public float totalTime;
    //wave number displays the current wave number
    public int waveNumber; 

    // Use this for initialization
    void Start()
    {
        isTime = true;
        totalTime = 250.0f;
        waveNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
