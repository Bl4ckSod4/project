using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MobInput : MonoBehaviour
{
    //public GameObject fps;
    public FixedJoystick MoveJoystick;
    public FixedButton JumpButton;
    public FixedTouchField TouchField;
    // Start is called before the first frame update
    void Start()
    {
        //fps = GetComponent<JoystickMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<RigidbodyFirstPersonController>();
        fps.runAxis = MoveJoystick.Direction;
        fps.jumpAxis = JumpButton.Pressed;
        fps.mouseLook.lookAxis = TouchField.TouchDist;
        
    }
}
