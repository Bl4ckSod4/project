using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponNoMono
{    
    public string weaponName = "MP5_black";
    public string weaponType = "MP5";
    public string weaponColor = "black";
    public string weaponId = "1";
    public bool equipped = false;
    public int price = 1000;

    [Header("Weapon_Params")]
    public float damage = 10f;//урон для текущего оружия
    public float aimness = 0.01f;//разброс пуль
    public float fireRate = 1.0f;//скорострельность

    public int shootRange = 50;//расстояние, с которого максимум можно стрелять с текущего оружия
    public int bulletsPerMag = 7;//патроны в обойме
    public int bulletsPerShot = 1;//пуль в выстреле (для дроби)

    public void Init(Weapon weapon)
    {
        weaponName = weapon.weaponName;
        weaponType = weapon.weaponType;
        weaponColor = weapon.weaponColor;
        weaponId = weapon.weaponId;
        equipped = weapon.equipped;
        price = weapon.price;
    }
    public void Init(WeaponNoMono weapon)
    {
        weaponName = weapon.weaponName;
        weaponType = weapon.weaponType;
        weaponColor = weapon.weaponColor;
        weaponId = weapon.weaponId;
        equipped = weapon.equipped;
        price = weapon.price;
    }
}
