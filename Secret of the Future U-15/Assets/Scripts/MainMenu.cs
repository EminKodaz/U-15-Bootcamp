using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene("kaanScene")
        Debug.Log("Game Started");
    }


    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("Game Quit");
    }

    public void Credits()
    {
        //SceneManager.LoadScene("Credits");
        Debug.Log("Credits");
    }
}

