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
    public float damage = 10f;//���� ��� �������� ������
    public float aimness = 0.01f;//������� ����
    public float fireRate = 1.0f;//����������������

    public int shootRange = 50;//����������, � �������� �������� ����� �������� � �������� ������
    public int bulletsPerMag = 7;//������� � ������
    public int bulletsPerShot = 1;//���� � �������� (��� �����)

    //private float timer = 0f;//��������������� ������ ��� ����������������
    //private float nextTimeToFire = 1f;//������ ��� ��������

    [Space(10)]
    public GameObject muzzleFlash;//������ �� ������ ��� ������� �������
    public Transform muzzle;//����� ������ ��� ������� �������
    public AIAgent agent;//������ �� �������
    public Transform targetTransform;//��������� ������� ����
    public Transform aimTransform;//��������� ����� ������(������ ��������� ������)
    public Vector3 targetOffset;//�������� ������� ������� �� ����� � ������ ��������(��� ����� �������� �� ������� � ����� ���� ������� ����, � ��� ����� � ���)
    public Transform bone;//����� �����, �������������� � ���� ������ �� �������� ������� ���� ����� aimTransform � targetTransform
    public GameObject impactEffect;//������ ������� ����, ���� �������� ����
    public int iterations = 10;//���������� �������� ������ AimAtTarget ������ ���� ��������� ��� ����� ������ �������� ������������
    [Range(0, 1)]
    public float weight = 1.0f;
    public float angleLimit = 90.0f;
    public float distanceLimit = 1.5f;

}
