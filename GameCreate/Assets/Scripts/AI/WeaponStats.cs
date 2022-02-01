using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [Header("Weapon_Params")]
    public float damage = 10f;
    public int shootRange = 50;
    public float aimness = 0.01f;//отдача
    //public float maxAimness = 0.3f;
    //public Vector3 offsetShoot;
    public float fireRate = 1.0f;
    public float timer = 0f;
    public float nextTimeToFire = 1f;
    public int bulletsPerMag = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
