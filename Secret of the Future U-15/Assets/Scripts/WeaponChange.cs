using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
    public GameObject ak47;

    private void Update()
    {
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
}
