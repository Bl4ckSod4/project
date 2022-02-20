using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour//скрипт назначающий товары в магазин, сайчас просто помещает случайное оружие из папки ресурсов
                                   //в будущем должен генерировать бойцов на покупку и прочее
{
    [SerializeField] WeaponCard[] weaponCards;
    [SerializeField] GameObject[] playerCards;

    private GameObject[] weapons;

    void Awake()//при загрузке
    {
        weapons = Resources.LoadAll<GameObject>("weapon/");
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Weapon"))
        {
            Destroy(i);
        }
        foreach (WeaponCard i in weaponCards)
        {
            i.SetWeapon(weapons[Random.Range(0, weapons.Length)]);
        }
    }
}
