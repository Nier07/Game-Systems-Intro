using System.Collections.Generic; //for dictionaries
using UnityEngine;
using UnityEngine.UI; // acsses to canvas UI elements

public class KeyBinds : MonoBehaviour
{
    //serialize field for one var serializable for containters of vars
    [SerializeField] public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    [System.Serializable]

    public struct KeyUISetup
    {
        public string keyName;
        public Text keyDisplaytext;
        public string defultKey;
    }

    public KeyUISetup[] baseSetup;
    public GameObject currentKey;
    public Color32 changedKey = new Color32(39, 171, 249, 255);
    public Color32 selectedKey = new Color32(239, 116, 36, 255);

    void Start()
    {
        //forloop to add keys to the dictionary on start, with the save for defult data
        //depending if we have save data

        for (int i = 0; i < baseSetup.Length; i++)
        {
            //add key according to the saved string or defult value
            //adds new key based of arry name to the dictionary then converting that data type to a typeof Keycode,
            //getting what key that is from the save file on the computer and dictionary, if there is no saved key then it will load the defult values
            keys.Add(baseSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode), 
                PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defultKey)));
            //for all the UI text elements change the dispaly to what the bind is in our dictionary
            baseSetup[i].keyDisplaytext.text = keys[baseSetup[i].keyName].ToString();
        }
    }

    public void SaveKeys()
    {
        //for each entry in dictionary
        foreach (var keyEntry in keys)
        {
            //ability to save or load info from registry edit (inbuilt way to save and load values)
            //setting is saving and getting is loading
            PlayerPrefs.SetString(keyEntry.Key, keyEntry.Value.ToString());
        }
        PlayerPrefs.Save();
    }
    public void changeKey(GameObject clickedKey)
    {
        currentKey = clickedKey;
        //if a key is selected
        if (clickedKey != null)
        {
            //change the color of the key to select key color
            clickedKey.GetComponent<Image>().color = selectedKey;
        }
    }

    private void OnGUI() //runs events such as key press
    {
        //temp reference to the string value of keycode
        string newKey = "";
        //temp reference to the current event
        Event e = Event.current;
        //if a key is selected
        if (currentKey != null)
        {
            //checks if the event is a keyboard event
            if (e.isKey)
            {
                //temp key reference is the event key that was pressed
                newKey = e.keyCode.ToString();
            }
            //there is an issue in uninty for getting the left and right shift keys
            //this is the a quick fix
            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "LeftShift";
            }
            //if we have set a key
            if (newKey != "")
            {
                //change the key value in the dictionary to the updated one
                keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                //change the dispay text to the updated one
                //gets the text component of the child | the text on the button
                currentKey.GetComponentInChildren<Text>().text = newKey;
                //change the color of button to changed key color
                currentKey.GetComponent<Image>().color = changedKey;
                //forget the object that was being edited
                currentKey = null;
            }
        }
    }
}
