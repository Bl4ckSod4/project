using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetTranslate : MonoBehaviour
{
    //public static SFPSC_FPSCamera cam;
    public GameObject target;
    public GameObject cam;
    public float amount = 6.0f;
    public float smoothAmount;
    public Vector3 offset;
    private Vector3 currentPosition;
    
    public float sensitivity = 0.5f;
    [HideInInspector]
    public float mouseX, mouseY;
    public float maxUpAngle = 0.1f;
    public float maxDownAngle = -0.1f;
    //public Transform player;
    public Transform targetPosition;
    public float timer;
    
    
    private void Awake()
    {
        
        //currentPosition = transform.position;
        
        //target = this;
        //cam_ = this.GetComponent<Camera>();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    
    private float rotX = 0.0f, rotY = 0.0f;
    [HideInInspector]
    public float rotZ = 0.0f;
    private void Start()
    {
        
        currentPosition = transform.localPosition;
    }
    private void Update()
    {
        //timer += Time.deltaTime;
        //currentPosition = transform.localPosition;
        // Mouse input
        mouseX = -Input.GetAxis("Mouse X") * sensitivity;
        mouseY = -Input.GetAxis("Mouse Y") * sensitivity;

        // Calculations
        //mouseX = Mathf.Clamp(mouseX, maxDownAngle, maxUpAngle);
        //mouseY = Mathf.Clamp(mouseY, maxDownAngle, maxUpAngle);
        //rotX = mouseX;
        //rotX = Mathf.Clamp(rotX, maxDownAngle, maxUpAngle);
        //rotY = mouseY;
        //rotY = Mathf.Clamp(rotY, maxDownAngle, maxUpAngle);
        //transform.Translate(rotX, rotY, rotZ);
        Vector3 finalPosition = new Vector3(mouseX, mouseY, 0);
        //Vector3 finalPosition = new Vector3(mouseX, mouseY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + currentPosition, Time.deltaTime * amount);
        //transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + currentPosition, Time.deltaTime * amount);
        //transform.localPosition = finalPosition;

        // Placing values
        //transform.Translate(rotX, rotY, rotZ);
        //if(timer > 1.5f)
       // {
            //transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + currentPosition, Time.deltaTime * amount);
            //transform.localPosition = currentPosition;
            //timer = 0.0f;
        //}
        //target.transform.Rotate(cam.transform.up * mouseX);
        //transform.position = currentPosition * timer;
        //transform.position = currentPosition;
    }

   // public void Shake(float magnitude, float duration)
    //{
     //   StartCoroutine(IShake(magnitude, duration));
   // }

    //private IEnumerator IShake(float mag, float dur)
   // {
       // WaitForEndOfFrame wfeof = new WaitForEndOfFrame();
       // for(float t = 0.0f; t <= dur; t += Time.deltaTime)
        //{
         //   rotZ = Random.Range(-mag, mag) * (t / dur - 1.0f);
        //    yield return wfeof;
       // }
       // rotZ = 0.0f;
  //  }
}
