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
            Time.timeScale = 0;
            PauseObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            HurtImage.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            PauseObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            HurtImage.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseObject.SetActive(false);
        open = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadFirstGameSceen(int Scene�d)
    {
        SceneManager.LoadScene(Scene�d);
    }

    public void KillCalculate(int _kill)
    {
        Kill += _kill;
    }
}
