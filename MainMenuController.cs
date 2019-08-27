using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This Class will be called from buttons and keys
public class MainMenuController : MonoBehaviour
{
	//Change the Keys in the inspector 
    [SerializeField]
    KeyCode QuitKey = KeyCode.Escape;

    [SerializeField]
    KeyCode PauseKey = KeyCode.P;
	//an indicator if the game is paused or not
    bool GamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(QuitKey))
            Quit();

        if (Input.GetKeyDown(PauseKey))
            if(!GamePaused)
                PauseGame();
            else
                UnPauseGame();
    }

	//use this to move between scenes
	//Called from Buttons
    public void GoToScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }

	//use this to quit the game called from Buttons
    public void Quit()
    {
        Application.Quit();
    }

	//use this to surf the net
	//Add the URL as a string in the Button Call
    public void GoToUrl(string URL)
    {
		//when opening while playing WebGl we have to open a new tab in the browser
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            Application.ExternalEval("window.open(\"" + URL + " \",\"_blank\")");
        else
            Application.OpenURL(URL);
    }
	
	//use this to Pause the Game you can call it from a key or from a button
    public void PauseGame()
    {
        Debug.Log("Pause");
        GamePaused = true;
        Time.timeScale = 0;
    }

	//use this to unPause the Game you can call it from a key or from a button
    public void UnPauseGame()
    {
        Debug.Log("UnPause");
        GamePaused = false;
        Time.timeScale = 1;
    }
}
