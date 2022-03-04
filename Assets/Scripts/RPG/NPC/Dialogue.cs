using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("Dialogue Text")]
    public string[] text;
    [Header("Current Index of Dialogue")]
    public int index;
    [Header("Show Dialogue Toggle")]
    public bool showDlg;
    private void OnGUI()
    {
        if (showDlg)
        {
            //box
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6, GameManager.scr.x * 16, GameManager.scr.y * 5), text[index]);

            //if wee are not a the end of conversation
            if (index < text.Length - 1)
            {
                //button to continue dialogue / 1++
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Next"))
                {
                    index++;
                }
            }
            //on last line of dialogue
            else
            {
                //button to exit dialogue
                if(GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Bye"))
                {
                    index = 0;
                    showDlg = false;
                    GameManager.gamePlayStates = GamePlayStates.Game;
                }

            }
        }
    }
}
