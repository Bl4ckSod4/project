using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public bool isEmpty = true;
    [SerializeField] GameObject[] sides;
    public GameObject member;

    public Vector3 ReturnPos(AIAgent memberLocal)
    {
        Vector3 result=new Vector3(0,0,0);
        if (member!=null)
        {
            return result;
        }
        member = memberLocal.gameObject;
        isEmpty = false;
        float magn0=9999.0f;
        foreach (GameObject i in sides)
        {
            float magn1 = (i.transform.position - member.transform.position).magnitude;
            if(magn1<magn0)
            {
                magn0 = magn1;
                result = i.transform.position;
            }
        }        
        return result;
        
    }

    private void Update()
    {
        if (member ==null)
        {
            member = null;
            isEmpty = true;
        }
    }
}
