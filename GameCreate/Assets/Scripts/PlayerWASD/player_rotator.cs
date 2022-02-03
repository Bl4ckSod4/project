using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_rotator : MonoBehaviour
{
    public static SFPSC_FPSCamera cam;
   // private Camera cam_;
    
    public float sensitivity = 3;
    [HideInInspector]
    public float mouseX;
    public float maxUpAngle = 80;
    public float maxDownAngle = -80;
    public Transform player;
    public Transform CameraPosition;
    
    private void Awake()
    {
        //cam_ = this.GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private float rotX = 0.0f, rotY = 0.0f;
    [HideInInspector]
    public float rotZ = 0.0f;
    private void Update()
    {
        // Mouse input
        mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // Calculations
        rotX = Mathf.Clamp(rotX, maxDownAngle, maxUpAngle);
        rotY += mouseX;

        // Placing values
        transform.localRotation = Quaternion.Euler(rotX, rotY, rotZ);
        player.Rotate(Vector3.up * mouseX);
        
    }

    public void Shake(float magnitude, float duration)
    {
        StartCoroutine(IShake(magnitude, duration));
    }

    private IEnumerator IShake(float mag, float dur)
    {
        WaitForEndOfFrame wfeof = new WaitForEndOfFrame();
        for(float t = 0.0f; t <= dur; t += Time.deltaTime)
        {
            rotZ = Random.Range(-mag, mag) * (t / dur - 1.0f);
            yield return wfeof;
        }
        rotZ = 0.0f;
    }
}