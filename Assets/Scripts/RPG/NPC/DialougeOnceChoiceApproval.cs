using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeOnceChoiceApproval : DialougeOneChoice
{
    [Header("Aprroval Score")]
    public int approval;
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
                    changeApproval(true);
                }

                //button for no | lower approval | Chnage to disliketext
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "No"))
                {
                    index = text.Length - 1;
                    changeApproval(false);
                }
            }
            else
            {
                //end button
                if (GUI.Button(new Rect(GameManager.scr.x * 15, GameManager.scr.y * 8.5f, GameManager.scr.x, GameManager.scr.y * 0.5f), "Bye"))
                {
                    index = 0;
                    showDlg = false;
                    GameManager.gamePlayStates = GamePlayStates.Game;
                }
            }
        }
    }
    public void changeApproval(bool approvalChange)
    {
        if (approvalChange)
        {
            approval++;
        }
        else
        {
            approval--;
        }
        
        approval = Mathf.Clamp(approval, -1, 1);

        switch (approval)
        {
            case -1:
                text = dislikeText;
                break;
            case 0:
                text = neutralText;
                break;
            case 1:
                text = likeText;
                break;
        }
    }
}
