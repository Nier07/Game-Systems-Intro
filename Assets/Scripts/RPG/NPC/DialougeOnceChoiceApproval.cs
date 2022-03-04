using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeOnceChoiceApproval : MonoBehaviour
{
    [Header("Display dialouge")]
    public string[] text;
    [Header("Index Markers")]
    public int choice;
    public int index;
    [Header("Aprroval Score")]
    public int approval;
    [Header("Toggle for dialouge visability")]
    public bool showDlg;
    [Header("The approval based responses")]
    public string[] likeText;
    public string[] neutralText;
    public string[] dislikeText;

    private void Start()
    {
        text = neutralText;
        approval = 0;
    }

    void OnGUI()
    {
        if (showDlg)
        {

            //box
            GUI.Box(new Rect(GameManager.scr.x * 0, GameManager.scr.y * 6, GameManager.scr.x * 16, GameManager.scr.y * 5), text[index]);
            if (index < text.Length -1 && index != choice)
            {
                //button
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Next")) //not choice
                {
                    //button - next / ++
                    index++;
                }
            }
            else if (choice == index)
            {
                //button for yes | raise approval | Change to liketext
                if (GUI.Button(new Rect(GameManager.scr.x * 14, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Yes"))
                {
                    index++;
                    chnageApproval(true);
                }

                //button for no | lower approval | Chnage to disliketext
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "No"))
                {
                    index = text.Length - 1;
                    chnageApproval(false);
                }
            }
            else
            {
                //end button
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Bye"))
                {
                    index = 0;
                }
            }
        }
    }
    public void chnageApproval(bool approveUpDown)
    {
        if (approveUpDown)
        {
            approval++;
        }
        else
        {
            approval--;
        }
        
        approval = Mathf.Clamp(approval, -1, 1);

        if (approval == 1)
        {
            text = likeText;
        }
        else if (approval == 0)
        {
            text = neutralText;
        }
        else
        {
            text = dislikeText;
        }
    }
}
