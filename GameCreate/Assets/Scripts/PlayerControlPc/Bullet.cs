using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;//�������� ����
    private GameObject player;//������ �� ������ �����

    void Start()
    {        
        player = GameObject.Find("Player");//�������� ������
        transform.rotation = player.transform.rotation;//����������� ���� � ������� ���� ������� �����
        Invoke("DestroySelf",3);//�������� ������ �� 3 �������, ����� �� ����� �� �������� ����
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//����������� ���� �����, ������ ����
    }

    void DestroySelf()//����������� ����
    {
        Destroy(gameObject);
    }
}
