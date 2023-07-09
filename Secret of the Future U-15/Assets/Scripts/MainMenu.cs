using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void StartGameOrCrdeits(int Scene›D)
    {
        SceneManager.LoadScene(Scene›D);
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("Game Quit");
    }
}

