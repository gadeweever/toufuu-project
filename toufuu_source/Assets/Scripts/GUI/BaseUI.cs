using UnityEngine;
using System.Collections;

public class BaseUI : MonoBehaviour
{

    public GameState gamestate;
    public Persona persona;
    public int selections;
    private string[] selectionNames;
    // Use this for initialization
    void Start()
    {
        gamestate = GetComponent<GameState>();
        persona = GetComponent<Persona>();
        selections = 10;
        selectionNames = new string[selections];
        selectionNames = SetSelections();
    }

    void OnGUI()
    {
        DrawTime();
        DrawAbilities();
        DrawWave();
        DrawPlayers();
        DrawBar();
        DrawEnemySelect();
        Debug.Log(selections);
        if (selections >= 0 && selections < 10 && Input.GetMouseButtonUp(0))
        {

            persona.selectedItem = selections;
            
        }
    }


    #region Drawers
    // draws the current remaining time against the current game
    void DrawTime()
    {
        GUI.Box(new Rect(Screen.width / 2 - 50, 50, 100, 30), FormatTime(gamestate.totalTime - Time.timeSinceLevelLoad));
    }

    //Draws Abilities for the Boxes
    void DrawAbilities()
    {
        GUI.Box(new Rect(Screen.width - 60, Screen.height - 65, 60, 30), "Ability 1");
        GUI.Box(new Rect(Screen.width - 60, Screen.height - 95, 60, 30), "Ability 2");
    }

    void DrawPlayers()
    {
        GUI.Box(new Rect(0, Screen.height - 35, Screen.width, 40), "");
        GUI.Box(new Rect(Screen.width * .80f - 50, Screen.height - 30, 100, 30), new GUIContent("Player4", "Health"));
        GUI.Box(new Rect(Screen.width * .60f - 50, Screen.height - 30, 100, 30), new GUIContent("Player3", "Health"));
        GUI.Box(new Rect(Screen.width * .40f - 50, Screen.height - 30, 100, 30), new GUIContent("Player2", "Health"));
        GUI.Box(new Rect(Screen.width * .20f - 50, Screen.height - 30, 100, 30), new GUIContent("Player1", "Health"));
    }

    void DrawBar()
    {

        GUI.Box(new Rect(Screen.width / 2 - persona.energy.current * 2.5f, Screen.height - 80, persona.energy.current * 5f, 40), persona.energy.current + "/" + persona.energy.max);
    }

    void DrawWave()
    {
        GUI.Box(new Rect(Screen.width - 60, 0, 60, 30), "Wave: " + gamestate.waveNumber);
    }

    void DrawEnemySelect()
    {
        selections = GUI.SelectionGrid(new Rect(0, 0, 200, Screen.height), selections, selectionNames, 2);


    }

    #endregion

    #region Auxilliary Functions
    //foramts the time for DrawTime
    private string FormatTime(float time)
    {
        float over = time % 60;
        if (over > 59.0f)
            return string.Format("{0:d}:00", (int)(time / 60) + 1);

        if (over < 10.0f)
            return string.Format("{0:d}:0{1:d}", (int)(time / 60), (int)over);

        return string.Format("{0:d}:{1:d}", (int)(time / 60), (int)over);

    }

    private string[] SetSelections()
    {
        string[] ns = { persona.asteroid.ToString(), "pls", "wow", "very cool", "such awesome", "interest", "BARK", "Woof!", "Dandellion", "Kop" };
        return ns;
    }
    #endregion




}
