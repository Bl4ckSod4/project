using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLight : MonoBehaviour
{

    Renderer lightTarget;
    GameObject player;

    private void Start()
    {
        lightTarget = gameObject.GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }
}
