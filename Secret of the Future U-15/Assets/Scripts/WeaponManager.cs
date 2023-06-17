using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public GameObject pistol;
    public GameObject rifle;
    public GameObject ak47;

    public ParticleSystem shootVfx;
    float nextTime = 0;
    bool isReloading = false;

    AudioSource pistolShootSound;
    ShootManager shootManager;

    private void Start()
    {
        pistolShootSound = GetComponent<AudioSource>();
        shootManager = GetComponent<ShootManager>();
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
        bool isLeftShiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (isWPressed)
        {
            _animator.SetBool("isMove", true);
            if (isLeftShiftPressed)
            {
                Debug.Log("içerdeyim");
                _animator.SetBool("isMove", false);
                _animator.SetBool("isRun", true);
            }
            else
            {
                _animator.SetBool("isMove", true);
                _animator.SetBool("isRun", false);
            }
        }
        else
        {
            _animator.SetBool("isMove", false);
            _animator.SetBool("isRun", false);
        }


        //if (isWPressed || isAPressed || isSPressed || isDPressed)
        //{
        //    _animator.SetBool("isMove", true);

        //}
        //if (isWPressed && isLeftShiftPressed)
        //{
        //    _animator.SetBool("isMove", false);
        //    _animator.SetBool("isRun", true);
        //}
        //else
        //{
        //    _animator.SetBool("isMove", false);
        //    _animator.SetBool("isRun", false);
        //}

        if (pistol != null && pistol.activeSelf)
        {
            nextTime += Time.deltaTime;
            if (nextTime >= .5f && !isReloading)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    shootVfx.Play();
                    pistolShootSound.Play();
                    shootManager.Shoot();
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
                    shootVfx.Play();
                    _animator.SetTrigger("Fire");
                    shootManager.Shoot();
                    nextTime = 0;
                }
            }
        }

        if (ak47 != null && ak47.activeSelf)
        {
            nextTime += Time.deltaTime;
            if (nextTime >= 2f && !isReloading)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    shootVfx.Play();
                    _animator.SetTrigger("Fire");
                    shootManager.Shoot();
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
                ak47.SetActive(false);

            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (rifle != null)
            {
                pistol.SetActive(false);
                ak47.SetActive(false);
                rifle.SetActive(true);


            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (ak47 != null)
            {
                ak47.SetActive(true);
                rifle.SetActive(false);
                pistol.SetActive(false);

            }
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
