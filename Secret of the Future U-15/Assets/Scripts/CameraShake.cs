using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f; // Sallanma süresi
    public float shakeAmount = 0.1f; // Sallanma miktarý

    private Vector3 originalPosition;
    private float shakeTimer = 0f;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ShakeCamera();
        }

        if (shakeTimer > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            shakeTimer = 0f;
            transform.localPosition = originalPosition;
        }
    }

    private void ShakeCamera()
    {
        shakeTimer = shakeDuration;
    }
}
