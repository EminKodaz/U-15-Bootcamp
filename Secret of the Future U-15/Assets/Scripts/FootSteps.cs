using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject audioSource;
    public Transform rayStart;
    public float range;
    public LayerMask layerMask;

    public void Footstep(bool Cl�b)
    {
        if (Cl�b)
        {
            RaycastHit hit;

            if (Physics.Raycast(rayStart.position, -rayStart.transform.up, out hit, range, layerMask))
            {
                if (hit.collider.CompareTag("grass"))
                {
                    PlayFootstepSound(audioSource , true);
                }
            }
        }
        else
        {
            PlayFootstepSound(audioSource, false);
        }
    }

    void PlayFootstepSound(GameObject audioSource,bool Cl�b)
    {
        audioSource.SetActive(Cl�b);
        //audioSource.pitch = Random.Range(0.8f, 1f);
    }

    private void Update()
    {
        Debug.DrawRay(rayStart.position, -range * rayStart.transform.up, Color.green);
    }
}
