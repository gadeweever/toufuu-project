using UnityEngine;
using System.Collections;
using System;

public class Persona : MonoBehaviour
{
    /* This class contains no constructor, but methods for setting values at the beginning of the game.
     * the reason for this is that there should only be maximum ONE Persona at any time, therefore
     * this class is reusable */

    #region Persona Qualities
    // represents the current energy a persona has to instantiate minions
    // this should be depleted using a time function, or with the available other functions
    public EnergyBar energy;

    public Asteroid myasteroid;
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
    public bool makingPath;
    public Pather lastPath;

    public void Start()
    {
        makingPath = false;
        selectedItem = 10;
        counter = 10;
        pos = 0;
        energy = GetComponent<EnergyBar>();
        guiVals = GetComponent<BaseUI>();
        lastPath = GetComponent<Pather>();
        myasteroid = GetComponent<Asteroid>();
        


    }

    public void Update()
    {
        myasteroid.myspeed = 0f; //ugly but it works
        #region freeform path creation
        if ((selectedItem >= 0 && selectedItem < 10) && !makingPath)
        {
            makingPath = true;
        }
        else
        {
            try
            {
                //if (Input.touches[0].phase == TouchPhase.Began && makingPath)
                if (Input.GetMouseButtonDown(0) && makingPath)
                {
                    lastPath.points = new Vector3[0];
                    //Debug.Log("Mouse Loc:" + Input.mousePosition);
                }
                if (Input.GetMouseButton(0) && makingPath)
                //if (Input.touches[0].phase == TouchPhase.Moved && makingPath)
                {
                    counter++;
                    if (counter >= 10)
                    {
                        Vector3[] temp = new Vector3[lastPath.points.Length + 1];
                        for (int i = 0; i < lastPath.points.Length; i++)
                        {
                            temp[i] = lastPath.points[i];
                        }
                        temp[lastPath.points.Length] = Input.mousePosition;
                        //Debug.Log(temp[lastPath.points.Length]);
                        //temp[lastPath.points.Length] = Input.touches[0].position;
                        counter = 0;
                        lastPath.points = temp;
                    }
                }
                if (Input.GetMouseButtonUp(0) && makingPath)
                //if (Input.touches[0].phase == TouchPhase.Ended && makingPath)
                {
                    counter = 10;
                    makingPath = false;
                    selectedItem = 10;
                    guiVals.selections = 10;
                    //Debug.Log("We drew a path");
                    Spawn(asteroid, lastPath);
                    lastPath.points = new Vector3[0];
                }
                /*
                if (Input.touches[0].phase == TouchPhase.Canceled && makingPath)
                {
                    counter = 30;
                    makingPath = false;
                    selectedItem = 10;
                    guiVals.selections = 10;
                    lastPath.points = new Vector3[0];
                }
                 */
            }
            catch(IndexOutOfRangeException)
            { 
                return; 
            }
            
        }
    }   

        #endregion


    public void Spawn(Transform enemy, Pather start)
    {
        //Debug.Log(Screen.width);//1366
        //Debug.Log(Screen.height);//598
        Vector3 scale = new Vector3((400f / Screen.width) * start.points[0].x, (180f / Screen.height) * start.points[0].y, 0);
        //Debug.Log(scale);
        enemy = UnityEngine.Object.Instantiate(enemy, scale, Quaternion.identity) as Transform;
        enemy.gameObject.GetComponent<Pather>().points = lastPath.points;
        //Debug.Log(enemy.position);
        enemy.gameObject.GetComponent<Pather>().makeLine();
        enemy.gameObject.GetComponent<Pather>().pathInit(enemy.position);
        //Debug.Log(enemy.gameObject.GetComponent<Pather>().points[0]);
        //enemy.gameObject.GetComponent<Pather>().points = lastPath.toTheWindows(start.points[0], start.points);
        //enemy.position = enemy.gameObject.GetComponent<Pather>().points[0];
        //Debug.Log("my points in order:");
        for (int i = 0; i < enemy.gameObject.GetComponent<Pather>().points.Length; i++) {
            Debug.Log(enemy.gameObject.GetComponent<Pather>().points[i]); }

        energy.current -= myasteroid.mycost * 3;
        
    }

    public void TimeDeplete()
    {
    }
}
