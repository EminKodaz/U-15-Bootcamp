using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrable : MonoBehaviour
{
    private Rigidbody rb;
    private Transform objectGrablepoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrablePoint)
    {
        this.objectGrablepoint = objectGrablePoint;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void Drop()
    {
        this.objectGrablepoint = null;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    private void FixedUpdate()
    {
        if (objectGrablepoint != null)
        {
            float lerpSpeed = 10;
            Vector3 NewPos = Vector3.Lerp(transform.position, objectGrablepoint.position,Time.deltaTime * lerpSpeed);
            rb.MovePosition(NewPos);
        }
    }
    public void RotateObject(float rotationAmount)
    {
        if (objectGrablepoint != null)
        {
            transform.RotateAround(objectGrablepoint.position, Vector3.up, rotationAmount);
        }
    }
}
