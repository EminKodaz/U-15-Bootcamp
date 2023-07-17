using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadScene;
    public Image LoadingFillImage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void StartGameOrCrdeits(int Scene›D)
    {
        StartCoroutine(LoadSceneAsync(Scene›D));
    }


    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("Game Quit");
    }

    IEnumerator LoadSceneAsync(int Scene›d)
    {
        LoadScene.SetActive(true);

        yield return new WaitForEndOfFrame();

        AsyncOperation operation = SceneManager.LoadSceneAsync(Scene›d);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingFillImage.fillAmount = progressValue;

            yield return null;
        }
    }
}

