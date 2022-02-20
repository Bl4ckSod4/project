using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour//������ ����������� ������ � �������, ������ ������ �������� ��������� ������ �� ����� ��������
                                   //� ������� ������ ������������ ������ �� ������� � ������
{
    [SerializeField] WeaponCard[] weaponCards;
    [SerializeField] GameObject[] playerCards;

    private GameObject[] weapons;

    void Awake()//��� ��������
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
