using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCounter : MonoBehaviour
{
    [SerializeField] Area areaCanvas;
    //Скрипт вешается на область и считает тех кто стоит в коллайдере объекта, работает в паре с наследником класса Area
    protected void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            areaCanvas.team1++;
        }
        if (other.CompareTag("Enemy"))
        {
            areaCanvas.team2++;
        }
    }
}
