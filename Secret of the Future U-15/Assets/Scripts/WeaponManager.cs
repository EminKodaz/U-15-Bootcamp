using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public GameObject pistol;
    public GameObject rifle;


    float nextTime = 0;
    bool isReloading = false;

    AudioSource pistolShootSound;


    private void Start()
    {
        pistolShootSound = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading) 
        {
            isReloading = true;
            StartCoroutine(ReloadDone(2));
            _animator.SetBool("reload", isReloading);
        }

        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isAPressed = Input.GetKey(KeyCode.A);
        bool isSPressed = Input.GetKey(KeyCode.S);
        bool isDPressed = Input.GetKey(KeyCode.D);

        if (isWPressed || isAPressed || isSPressed || isDPressed)
        {
            _animator.SetBool("isMove", true);
           
        }
        else
        {
            _animator.SetBool("isMove", false);
        }

        if (pistol != null && pistol.activeSelf)
        {
            nextTime += Time.deltaTime;
            if (nextTime >= .5f && !isReloading)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pistolShootSound.Play();
                    _animator.SetTrigger("Fire");
                    nextTime = 0;
                }
            }
        }

        if (pistol != null && rifle.activeSelf)
        {
            nextTime += Time.deltaTime;
            if (nextTime >= 2f && !isReloading)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _animator.SetTrigger("Fire");
                    nextTime = 0;
                }
            }
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (pistol != null)
            {
                pistol.SetActive(true);
                rifle.SetActive(false);

            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (rifle != null)
            {
                pistol.SetActive(false);
                rifle.SetActive(true);


            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
        }


    }

    //IEnumerator ShootDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    _animator.SetBool("isShooting", false);
    //}

    IEnumerator ReloadDone(float delay)
    {
        yield return new WaitForSeconds(delay);
        isReloading = false;
        _animator.SetBool("reload", isReloading);
    }

    //IEnumerator RunChecker(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    _animator.SetBool("isMove", false);
    //}
}
