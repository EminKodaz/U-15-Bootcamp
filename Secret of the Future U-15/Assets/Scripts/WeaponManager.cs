using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponManager : MonoBehaviour
{
    public Animator _animator;

    public ParticleSystem shootVfx;
    public float nextTime = 0;
    public bool isReloading = false;

    public AudioSource pistolShootSound;
    public ShootManager shootManager;
    public bool isRifle;
    public float AttackTime;
    public bool focusGuns;
    public Animator camAnim;
    public Camera fpsCam;
    public bool InventoryOpenOrClose = false;
    public bool serialAttack = false;
    public int bulletLength;
    public int bulletNumber;
    public bool finishedBullet = false;
    public Text bulletLenghtText;

    private void Start()
    {
        pistolShootSound = GetComponent<AudioSource>();
        shootManager = GetComponent<ShootManager>();
    }

    public abstract void Shoots();
    public abstract void Focus();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading || finishedBullet == true)
        {
            isReloading = true;
            _animator.SetBool("reload", isReloading);
            finishedBullet = false;

        }
        nextTime += Time.deltaTime;
        if (nextTime >= AttackTime && !isReloading)
        {
            if (Input.GetMouseButton(0) && InventoryOpenOrClose == false && serialAttack == true && bulletNumber > 0)
            {
                Shoots();
                nextTime = 0;
                bulletNumber -= 1;
                if (bulletNumber <= 0)
                {
                    finishedBullet = true;
                }
            }
            else if(Input.GetMouseButtonDown(0) && InventoryOpenOrClose == false && serialAttack == false && bulletNumber > 0)
            {
                Shoots();
                nextTime = 0;
                bulletNumber -= 1;
                if (bulletNumber <= 0)
                {
                    finishedBullet = true;
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && InventoryOpenOrClose == false)
        {
            Focus();
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
        if (bulletLenghtText != null)
        {
            bulletLenghtText.text = bulletNumber.ToString() + " / " + bulletLength;
        }
    }
    public void ReloadTime()
    {
        isReloading = false;
        bulletNumber = bulletLength;
        _animator.SetBool("reload", isReloading);
    }
}
