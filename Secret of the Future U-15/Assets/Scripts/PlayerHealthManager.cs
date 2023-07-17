using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public float health;
    public float CurrentHealth;
    public GameObject DiedBg;
    public GameObject DiedBt;
    public GameObject DiedBr;
    public Image DiedBgF;
    public Text DiedBgT;
    public Image hurtImage;
    bool died = false;
    [SerializeField]float healthTimer;
    [SerializeField] GameObject DiedSound;

    private void Start()
    {
        CurrentHealth = health;
        DiedBg.SetActive(false);
        DiedSound.SetActive(false);
    }

    private void Update()
    {
        if (died)
        {
            healthTimer += Time.deltaTime + 0.01f;
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        UpdatedImage();

        if (CurrentHealth <= 0)
        {
            GameManager.instance.died = true;
            died = true;
            Die();
        }
    }
    private void Die()
    {
        DiedBg.SetActive(true);
        Color splatterAlpha = DiedBgF.color;
        splatterAlpha.a = healthTimer;
        DiedBgF.color = splatterAlpha;
        GetComponentInChildren<WeaponManager>().enabled = false;
        GetComponentInParent<FirstPersonController>().enabled = false;
        GetComponentInChildren<AudioSource>().enabled = false;
        DiedSound.SetActive(true);
        StartCoroutine(TimeZeroWorld());
    }

    public void UpdatedImage()
    {
        Color splatterAlpha = hurtImage.color;
        splatterAlpha.a =(1) - (CurrentHealth / health);
        hurtImage.color = splatterAlpha;
    }

    IEnumerator TimeZeroWorld()
    {
        yield return new WaitForSeconds(1);
        DiedBgT.gameObject.SetActive(true);
        DiedBt.SetActive(true);
        if (DiedBr != null)
        {
            DiedBr.SetActive(true);
        }
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

    }
}
