using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GamePlayStates gamePlayStates;
    public static Vector2 scr;
    private float pixelsPerUnit;
    // Start is called before the first frame update
    void Start()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;

        gamePlayStates = GamePlayStates.Game;
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width/16 != scr.x)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
        //toggles cursor lockstate for each game mode
        switch (gamePlayStates)
        {
            case GamePlayStates.PreGame:
                if (!Cursor.visible)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case GamePlayStates.Game:
                if (Cursor.visible)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            case GamePlayStates.MenuPause:
                if (!Cursor.visible)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case GamePlayStates.PostGame:
                if (Cursor.visible)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            default:
                if (!Cursor.visible)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
        }
    }
}

public enum GamePlayStates
{
    PreGame, //main menu
    Game, //the game
    MenuPause, //in game menu
    PostGame //death | respawn
}