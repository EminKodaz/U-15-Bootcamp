using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseObject;

    [SerializeField] private CharecterController m_Charecter;

    public bool open;
    public bool isFollowingDad = false;

    public static GameManager instance;
    public bool MissionFirst = false, MissionSecond = false, MissionThird = false;
    public GameObject HurtImage;
    [SerializeField] private Text KillCount;
    private int Kill;

    [Header("Load Options")]
    public GameObject LoadScene;
    public Image LoadingFillImage;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            open = !open;
            PauseObjectOpen(open);
        }

        if (KillCount != null)
        {
            KillCount.text = " Kill : " + Kill;
        }
    }

    public void PauseObjectOpen(bool open)
    {
        if (open)
        {
            if (m_Charecter != null)
            {
                m_Charecter.speed = 0;
            }
            Time.timeScale = 0;
            PauseObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            if (HurtImage != null)
            {
                HurtImage.SetActive(false);
            }
        }
        else
        {
            if (m_Charecter != null)
            {
                m_Charecter.speed = 5f;
            }

            Time.timeScale = 1;
            PauseObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            if (HurtImage != null)
            {
                HurtImage.SetActive(true);
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseObject.SetActive(false);
        open = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadFirstGameSceen(int Scene›d)
    {
        SceneManager.LoadScene(Scene›d);
    }

    public void KillCalculate(int _kill)
    {
        Kill += _kill;
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
}
