using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    [SerializeField]
    private float speed;
    [SerializeField] private int Scene›d;
    public GameObject PressText;
    public Text TalkText;

    bool LoadSceneActive;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        if (PressText != null)
        {
            PressText.SetActive(false);
        }
        if (TalkText != null)
        {
            TalkText.gameObject.SetActive(true);
        }
        StartCoroutine(TextDest());
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        vertical = Input.GetAxis("Vertical");

        gameObject.transform.Translate(speed / 10 * horizontal, 0.0f, speed / 10 * vertical);

        if (LoadSceneActive)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                LoadSceneManager.instance.LoadScenes(Scene›d);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameLoad"))
        {
            PressText.SetActive(true);
            LoadSceneActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GameLoad"))
        {
            PressText.SetActive(false);
            LoadSceneActive = false;
        }
    }

    IEnumerator TextDest()
    {
        yield return new WaitForSeconds(2);
        if (TalkText != null)
        {
            TalkText.gameObject.SetActive(false);
        }
    }
}
