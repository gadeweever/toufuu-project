using UnityEngine;
using System.Collections;

public class Persona : MonoBehaviour
{
    /* This class contains no constructor, but methods for setting values at the beginning of the game.
     * the reason for this is that there should only be maximum ONE Persona at any time, therefore
     * this class is reusable */

    #region Persona Qualities
    // represents the current energy a persona has to instantiate minions
    // this should be depleted using a time function, or with the available other functions
    public EnergyBar energy;


    public BaseUI guiVals;
    // currentEnemyCount: enemies currently instantiated
    public int currentEnemyCount;

    // maxQueue: max number of queueable minions to instantiate
    public int maxQueue;

    public int selectedItem;

    //list of enemies currently on the field
    public Transform asteroid;


    //energy bars to represent energy

    //list of specific enemy units
    public Enemy[] special_units;

    //list of specificInstanced mini bosses;
    public MiniBoss[] special_mini_boss;

    //array of available units;
    public Enemy[] units;

    //array of available mini bosses
    public MiniBoss[] miniBosses;
    #endregion

    #region Extra Class Variables
    // timeConstant: Multiplier used to speed up or slow down depletion of energy
    // provides easy acess in GUI for testing different values until a constant decision is made
    private float timeConstant;
    #endregion

    public void ability1() { }
    public void ability2() { }

    private int counter;
    private int pos;
    public bool makingPath;
    public Pather lastPath;

    public void Start()
    {
        makingPath = false;
        selectedItem = 10;
        counter = 30;
        pos = 0;
        energy = GetComponent<EnergyBar>();
        guiVals = GetComponent<BaseUI>();
        lastPath = GetComponent<Pather>();
        GetComponent<Asteroid>().myspeed = 0f;


    }

    public void Update()
    {
        #region freeform path creation
        if ((selectedItem >= 0 && selectedItem < 10) && !makingPath)
        {
            makingPath = true;
        }
        else
        { 
            if (Input.GetMouseButtonDown(0) && makingPath)
            {
                lastPath.points = new Vector3[0];
                Debug.Log("Mouse Loc:" + Input.mousePosition);
            }
            if (Input.GetMouseButton(0) && makingPath)
            {
                counter++;
                if (counter >= 30)
                {
                    Vector3[] temp = new Vector3[lastPath.points.Length + 1];
                    for (int i = 0; i < lastPath.points.Length; i++)    
                    {
                        temp[i] = lastPath.points[i];
                    }
                    temp[lastPath.points.Length] = Input.mousePosition;
                    counter = 0;
                    lastPath.points = temp;
                }
            }
            if (Input.GetMouseButtonUp(0) && makingPath)
            {
                counter = 30;
                makingPath = false;
                selectedItem = 10;
                guiVals.selections = 10;

                Debug.Log("We drew a path");
                Spawn(asteroid, lastPath);
            }
        }
    }

        #endregion


    public void Spawn(Transform enemy, Pather start)
    {
        enemy = Object.Instantiate(enemy, start.points[0], Quaternion.identity) as Transform;
        enemy.gameObject.GetComponent<Pather>().points = lastPath.points;
        enemy.gameObject.GetComponent<Pather>().makeLine();
        enemy.gameObject.GetComponent<Pather>().points = lastPath.toTheWindows(start.points[0], start.points);
        enemy.position = enemy.gameObject.GetComponent<Pather>.points[0];
        debug.log("my points in order:");
        for (int i = 0; i < enemy.gameObject.GetComponent<Pather>.points.Length; i++) { debug.log(enemy.gameObject.GetComponent<Pather>.points[i]); }
    }

    public void TimeDeplete()
    {
    }
}
