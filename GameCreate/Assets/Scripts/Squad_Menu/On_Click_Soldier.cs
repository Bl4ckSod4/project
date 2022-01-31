using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class On_Click_Soldier : MonoBehaviour
{
    public GameObject Bio;
    public GameObject soldier;
    public GameObject Canvaz;

    private void OnMouseDown()
    {
        Bio.SetActive(true);
        Canvaz.SetActive(false);
        soldier.SetActive(true);
    }

}
