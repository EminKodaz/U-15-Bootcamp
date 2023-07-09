using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    public GameObject LoadScene;
    public Image LoadingFillImage;
    public GameObject Menu;
    public GameObject MenuBG;
    public GameObject ButtonBG;
    public GameObject ButtonStartBG;
    bool open;
    public static LoadSceneManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            open = !open;
            Resume(open);
        }
    }

    public void LoadScenes(int Scene›d)
    {
        StartCoroutine(LoadSceneAsync(Scene›d)); 
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

    public void Resume(bool open)
    {
        Menu.SetActive(open);
        MenuBG.SetActive(open);
        ButtonBG.SetActive(open);
        ButtonStartBG.SetActive(false);
        if (open)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
