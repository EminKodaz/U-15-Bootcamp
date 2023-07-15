using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject audioSourceGrass;
    public GameObject audioSourceasphalt;
    public GameObject audioSourceMetal;
    public Transform rayStart;
    public float range;
    public LayerMask layerMask;

    public void Footstep(bool Clýb)
    {
        if (Clýb)
        {
            RaycastHit hit;

            if (Physics.Raycast(rayStart.position, -rayStart.transform.up, out hit, range, layerMask))
            {
                if (hit.collider.CompareTag("grass"))
                {
                    PlayFootstepSound(audioSourceGrass, true);
                    PlayFootstepSound(audioSourceasphalt, false);
                    PlayFootstepSound(audioSourceMetal, false);
                }

                if (hit.collider.CompareTag("Road"))
                {
                    PlayFootstepSound(audioSourceasphalt, true);
                    PlayFootstepSound(audioSourceGrass, false);
                    PlayFootstepSound(audioSourceMetal, false);
                }

                if (hit.collider.CompareTag("Metal"))
                {
                    PlayFootstepSound(audioSourceMetal, true);
                    PlayFootstepSound(audioSourceGrass, false);
                    PlayFootstepSound(audioSourceasphalt, false);
                }
            }
        }
        else
        {
            PlayFootstepSound(audioSourceGrass, false);
            PlayFootstepSound(audioSourceasphalt, false);
            PlayFootstepSound(audioSourceMetal, false);
        }
    }

    void PlayFootstepSound(GameObject audioSource,bool Clýb)
    {
        audioSource.SetActive(Clýb);
        //audioSource.pitch = Random.Range(0.8f, 1f);
    }

    private void Update()
    {
        Debug.DrawRay(rayStart.position, -range * rayStart.transform.up, Color.green);
    }
}
