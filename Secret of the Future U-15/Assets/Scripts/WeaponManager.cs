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


        bool isWPressedW = Input.GetKey(KeyCode.W);
        bool isWPressedA = Input.GetKey(KeyCode.A);
        bool isWPressedS = Input.GetKey(KeyCode.S);
        bool isWPressedD = Input.GetKey(KeyCode.D);
        bool isLeftShiftPressed = Input.GetKey(KeyCode.LeftShift);
        bool isCtrlPressed = Input.GetKey(KeyCode.LeftControl);

        if (isWPressedW || isWPressedA || isWPressedS || isWPressedD)
        {
            _animator.SetBool("isMove", true);
            if (isLeftShiftPressed)
            {
                _animator.SetBool("isMove", false);
                _animator.SetBool("isRun", true);
                GetComponentInParent<CharacterController>().height = 2f;
            }
            else if(isCtrlPressed)
            {
                GetComponentInParent<CharacterController>().height = 1f;
            }
            else
            {
                _animator.SetBool("isMove", true);
                _animator.SetBool("isRun", false);
                GetComponentInParent<CharacterController>().height = 2f;
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
