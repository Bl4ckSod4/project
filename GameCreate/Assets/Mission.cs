using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    [SerializeField] string mission="default";
    [SerializeField] Text missinText;
    [SerializeField] GameObject plate;
    // Start is called before the first frame update
    void Start()
    {
        missinText.text = mission;
        gameObject.AddComponent<MeshCollider>().sharedMesh = plate.GetComponent<MeshCollider>().sharedMesh;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Hub.instanse.SetMission(mission);
    }
}
