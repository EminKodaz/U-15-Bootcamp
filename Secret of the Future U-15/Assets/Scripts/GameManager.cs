using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseObject;

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
    public GameObject LoadMenu;
    public Image LoadMenuI;


    [SerializeField] private WeaponManager[] gun;
    public GameObject MapImage;
    public GameObject MapImagem2;
    public GameObject MapImagem3;
    bool m_open;
    public bool died;
    public bool TabOpen;

    private void Awake()
    {
        instance = this;
        TabOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            m_open = !m_open;

            if (MapImage != null && !MissionFirst)
            {
                MapImage.SetActive(m_open);
            }
            else if(MapImage != null && MissionFirst && !MissionSecond)
            {
                MapImagem2.SetActive(m_open);
            }
            else if(MapImage != null && MissionFirst && MissionSecond && !MissionThird)
            {
                MapImagem3.SetActive(m_open);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !died)
        {
            open = !open;
            TabOpen = !TabOpen;
            PauseObjectOpen(open);
            if(MapImage != null)
                MapImage.SetActive(false);
            if (MapImagem2 != null)
                MapImagem2.SetActive(false);
            if (MapImagem3 != null)
                MapImagem3.SetActive(false);
        }

        if (KillCount != null)
        {
            KillCount.text = " Le˛ : " + Kill;
        }
    }

    public void PauseObjectOpen(bool open)
    {
        if (open)
        {
            Time.timeScale = 0;
            if (PauseObject != null)
            {
                PauseObject.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.Confined;
            if (HurtImage != null)
            {
                HurtImage.SetActive(false);
            }

            foreach (var guns in gun)
            {
                guns.enabled = false;
            }
        }
        else
        {
            Time.timeScale = 1;
            PauseObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            if (HurtImage != null)
            {
                HurtImage.SetActive(true);
            }

            foreach (var guns in gun)
            {
                guns.enabled = true;
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
        Time.timeScale = 1;
        StartCoroutine(LoadMenuAsync(Scene›d));
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

    public IEnumerator LoadMenuAsync(int Scene›d)
    {
        LoadMenu.SetActive(true);

        yield return new WaitForEndOfFrame();

        AsyncOperation operation = SceneManager.LoadSceneAsync(Scene›d);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadMenuI.fillAmount = progressValue;

            yield return null;
        }
    }
}
