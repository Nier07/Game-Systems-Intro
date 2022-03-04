using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeOneChoice : MonoBehaviour
{
    public string[] text;
    public int choiceIndex;
    public int index;
    public bool showDlg;

    void OnGUI()
    {
        if (showDlg)
        {
            //box
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6, GameManager.scr.x * 16, GameManager.scr.y * 5), text[index]);
            if (index < text.Length - 1 && index != choiceIndex)
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Next")) //not choice
                {
                    //button - next / ++
                    index++;
                }
            }

            else if (choiceIndex == index) // choice
            {
                //button yes / ++
                if (GUI.Button(new Rect(GameManager.scr.x * 14, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Yes"))
                {
                    index++;
                }
                //button no / end
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "No"))
                {
                    index = text.Length -1;
                }
            }
            else //end dialouge
            {
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Bye"))
                {
                    index = 0;
                    showDlg = false;
                }
            }
            
        }
    }
}
