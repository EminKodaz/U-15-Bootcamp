using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    float nextTime = 0;
    bool isReloading = false;

    AudioSource pistolShootSound;


    private void Start()
    {
        pistolShootSound = GetComponent<AudioSource>();
    }


    private void Update()
    {
        nextTime += Time.time;
        if (nextTime >= 2f && !isReloading)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pistolShootSound.Play();
                _animator.SetTrigger("Fire");
                nextTime = 0;
            }
        }

        /*if (Input.GetMouseButtonDown(0)) 
        {
            pistolShootSound.Play();
            _animator.SetBool("isShooting", true);
            StartCoroutine(ShootDelay(0.1f));       
        }*/

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


    }

    IEnumerator ShootDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _animator.SetBool("isShooting", false);
    }

    IEnumerator ReloadDone(float delay)
    {
        yield return new WaitForSeconds(delay);
        isReloading = false;
        _animator.SetBool("reload", isReloading);
    }

    IEnumerator RunChecker(float delay)
    {
        yield return new WaitForSeconds(delay);
        _animator.SetBool("isMove", false);
    }
}
