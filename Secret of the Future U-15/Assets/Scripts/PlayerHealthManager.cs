using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public float health;
    public float CurrentHealth;

    [SerializeField] private Image hurtImage;
    [SerializeField] private float hurtTimer;

    private bool titremeDevamEdiyor = false;
    private Vector3 orijinalPozisyon;
    public Transform Camera;
    private float titremeSiddeti = 0.1f;
    private float titremeSure = 1f;
    public float maxX;
    public float minX;

    private void Start()
    {
        CurrentHealth = health;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        UpdatedImage();

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("I dead");
    }

    public void UpdatedImage()
    {
        Color splatterAlpha = hurtImage.color;
        splatterAlpha.a =(1) - (CurrentHealth / health);
        hurtImage.color = splatterAlpha;
    }
}
