using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    [SerializeField]
    private float speed;

    public GameObject PressText;

    // Start is called before the first frame update
    void Start()
    {
        PressText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        vertical = Input.GetAxis("Vertical");

        gameObject.transform.Translate(speed / 10 * horizontal, 0.0f, speed / 10 * vertical);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameLoad"))
        {
            PressText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GameLoad"))
        {
            PressText.SetActive(false);
        }
    }
}
