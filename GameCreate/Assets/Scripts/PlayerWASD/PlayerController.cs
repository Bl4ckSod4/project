using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasGun;
    public Gun gun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) &&gun!=null)
        {
            gun.Shoot();
        }
    }
}
