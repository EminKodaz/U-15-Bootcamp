using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    public int TotalBullet;
    public int CurrentBullet;
    public int bulletNumber;
    public bool finishedBullet = false;
    public bool fire = false;

    public GameObject[] zombies;
    public static WeaponManager instanceW;

    private void Awake()
    {
        instanceW = this;
    }

    private void Start()
    {
        CurrentBullet = bulletNumber;
        pistolShootSound = GetComponent<AudioSource>();
        shootManager = GetComponent<ShootManager>();
    }

    public abstract void Shoots();
    public abstract void Focus();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && TotalBullet > 0 || finishedBullet == true)
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
                fire = true;
                Shoots();
                nextTime = 0;
                bulletNumber -= 1;
                if (bulletNumber <= 0 && TotalBullet > 0)
                {
                    finishedBullet = true;
                }
            }
            else if (Input.GetMouseButtonDown(0) && InventoryOpenOrClose == false && serialAttack == false && bulletNumber > 0)
            {
                fire = true;
                Shoots();
                nextTime = 0;
                bulletNumber -= 1;
                if (bulletNumber <= 0 && TotalBullet > 0)
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
        bool isCtrlPressed = Input.GetKey(KeyCode.C);

        if (isWPressedW || isWPressedA || isWPressedS || isWPressedD)
        {
            _animator.SetBool("isMove", true);
            if (isLeftShiftPressed)
            {
                _animator.SetBool("isMove", false);
                _animator.SetBool("isRun", true);
                GetComponentInParent<CharacterController>().height = 2f;
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

        if (isCtrlPressed)
        {
            GetComponentInParent<CharacterController>().height = 1f;
        }
    }
    public void ReloadTime()
    {
        TotalBullet += bulletNumber;
        isReloading = false;
        if (TotalBullet >= CurrentBullet)
        {
            TotalBullet -= CurrentBullet;
            bulletNumber = CurrentBullet;
        }
        else
        {
            bulletNumber = TotalBullet;
            TotalBullet -= TotalBullet;
        }
        _animator.SetBool("reload", isReloading);
    }

    public void AddBullet(int id, Item item, GameObject gameObject)
    {
        if (id == 2 && GetComponentInParent<WeaponChange>().pistolActive)
        {
            TotalBullet += CurrentBullet;
            InventoryManager.Instance.Remove(item);
            Destroy(gameObject);
        }
        if (id == 1 && GetComponentInParent<WeaponChange>().ak47ActiveReceived)
        {
            TotalBullet += CurrentBullet;
            InventoryManager.Instance.Remove(item);
            Destroy(gameObject);
        }
        if (id == 3 && GetComponentInParent<WeaponChange>().rifleActiveReceived)
        {
            TotalBullet += CurrentBullet;
            InventoryManager.Instance.Remove(item);
            Destroy(gameObject);
        }

        if (id == 4)
        {
            GetComponentInParent<PlayerHealthManager>().CurrentHealth += 70;
            GetComponentInParent<PlayerHealthManager>().UpdatedImage();
            InventoryManager.Instance.Remove(item);
            Destroy(gameObject);
        }



        if (id == 5)
        {
            zombies = GameObject.FindGameObjectsWithTag("Zombies");

            foreach (var zombi in zombies)
            {
                zombi.GetComponent<ZombieAtacker>().speed = 0.5f;
                GetComponentInParent<FirstPersonController>().MoveSpeed = 6;
            }


            InventoryManager.Instance.Remove(item);
            StartCoroutine(BackSpeedZombies(zombies));
            Destroy(gameObject);
        }
    }

    private IEnumerator BackSpeedZombies(GameObject[] zombies)
    {
        yield return new WaitForSeconds(5);

        foreach (var zombi in zombies)
        {
            if (zombi != null)
            {
                zombi.GetComponent<ZombieAtacker>().speed = 1f;
                GetComponentInParent<FirstPersonController>().MoveSpeed = 4;

            }
        }
    }

    public void FireFalseChange()
    {
        fire = false;
    }
}
