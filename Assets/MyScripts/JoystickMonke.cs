using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine.InputSystem.LowLevel;
using static Monkey2D;

public class JoystickMonke : MonoBehaviour
{
    public static JoystickMonke SharedJoystick;

    public float moveX;
    public float moveY;

    public float maxJoyRotDeg = 0.0f;
    public float LinSpeed = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        SharedJoystick = this;
    }

    void Start()
    {
        //USBJoystick = CTIJoystick.current;
        LinSpeed = PlayerPrefs.GetFloat("LinearSpeed");
        maxJoyRotDeg = PlayerPrefs.GetFloat("AngularSpeed");
    }

    private void FixedUpdate()
    {
        //moveX = -USBJoystick.x.ReadValue();
        //moveY = -USBJoystick.y.ReadValue();

        if (Input.GetKey(KeyCode.W))
        {
            moveX = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveX = -1.0f;
        }
        else
        {
            moveX = 0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveY = 1.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveY = -1.0f;
        }
        else
        {
            moveY = 0f;
        }

        float currentSpeed = moveX * LinSpeed;
        float currentRot = moveY * maxJoyRotDeg;
        transform.position = transform.position + transform.forward * currentSpeed * Time.fixedDeltaTime;
        transform.Rotate(0f, currentRot * Time.fixedDeltaTime, 0f);
    }
}