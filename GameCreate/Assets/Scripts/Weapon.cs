using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public string weaponName = "MP5";
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

    //private float timer = 0f;//вспосогательный таймер для скорострельности
    //private float nextTimeToFire = 1f;//таймер для выстрела

    [Space(10)]
    public GameObject muzzleFlash;//ссылка на префаб для дульной вспышки
    public Transform muzzle;//точка спавна для дульной вспышки
    public AIAgent agent;//ссылка на солдата
    public Transform targetTransform;//положение текущей цели
    public Transform aimTransform;//положение конца оружия(вектор направлен вперед)
    public Vector3 targetOffset;//смещение прицела солдата на врага в районе туловища(без этого смещения он целится в пивот поин текущей цели, а она внизу у ног)
    public Transform bone;//кость спины, поворачивается к цели исходя из расчетов разницы угла между aimTransform и targetTransform
    public GameObject impactEffect;//префаб эффекта искр, куда попадает пуля
    public int iterations = 10;//количество итераций метода AimAtTarget должно быть несколько для более точных расчетов прицеливания
    [Range(0, 1)]
    public float weight = 1.0f;
    public float angleLimit = 90.0f;
    public float distanceLimit = 1.5f;

}
