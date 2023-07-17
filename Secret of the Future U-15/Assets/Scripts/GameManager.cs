using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseObject;
    [SerializeField] private GameObject Envanter›nformation;
    [SerializeField] private GameObject Map›nformation;
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
        if (Envanter›nformation != null && Map›nformation != null)
        {
            Envanter›nformation.SetActive(true);
            StartCoroutine(Envanter›nformationClose());
        }
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
            LockCursor(open);
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

            ResumeGame();
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
        open = false;
        Time.timeScale = 1;
        PauseObject.SetActive(false);

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

    IEnumerator Envanter›nformationClose()
    {
        yield return new WaitForSeconds(5);
        Envanter›nformation.SetActive(false);
        Map›nformation.SetActive(true);
        yield return new WaitForSeconds(3);
        Map›nformation.SetActive(false);
    }

    public void LockCursor(bool open)
    {
        PauseObjectOpen(open);
        if (MapImage != null)
            MapImage.SetActive(false);
        if (MapImagem2 != null)
            MapImagem2.SetActive(false);
        if (MapImagem3 != null)
            MapImagem3.SetActive(false);
        Cursor.lockState = open ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
