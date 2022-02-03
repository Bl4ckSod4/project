using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int hp = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)

    {        
        if(other.CompareTag("Bullet"))
        {
            hp--;
            if(hp<1)
            {
                Destroy(base.gameObject);
            }
        }
        
    }    

    }
