using UnityEngine;
using UnityEngine.SceneManagement; //change and manipualte scenes

public class MenuHandler : MonoBehaviour
{
    //Change scene based off scene index value
    public void ChangesScene(int sceneIndex)
    {
        //use Scene Manager load scene that corresponds to the scene index int
        SceneManager.LoadScene(sceneIndex);
    }
    //Quit game
    public void QuitGame()
    {
        //#if is developer code
        //only runs if in the unity engine not the application
        #if UNITY_EDITOR
        //if unity is in playmode when this function is activated it will get out of playmode.
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        //Quirs the Application
        Application.Quit();
    }
}
