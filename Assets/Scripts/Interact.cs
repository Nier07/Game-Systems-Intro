using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("RPG Game/Character/Interact")]
public class Interact : MonoBehaviour
{
    void Update()
    {
        //if a interact key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //create ray shooting forward from the camera
            Ray interact;
            //assigning origin at center of screem
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            //create hit info
            RaycastHit hitInfo;
            //if physics raycasts hits somthing within 10 units
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region NPC tag
                //raycast hits info tagged NPC
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    Debug.Log("NPC");
                }
                #endregion

                #region Item
                //raycast hits info tagged Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Item");
                    #endregion
                }

                #region Chest
                //raycast hits info tagged Chest
                if (hitInfo.collider.CompareTag("Chest"))
                {
                    Debug.Log("Chest");
                }
                #endregion
            }
        }
    }
    private void OnGUI()
    {
        //Interates through all x and y
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                GUI.Box(new Rect(GameManager.scr.x * x, GameManager.scr.y * y,
                    GameManager.scr.x, GameManager.scr.y), x+":"+y);
            }
        }
        GUI.Box(new Rect(GameManager.scr.x * (8f - 0.125f), GameManager.scr.y * (4.5f - 0.125f), 
            GameManager.scr.x * .25f, GameManager.scr.y * .25f), "");
    }
}