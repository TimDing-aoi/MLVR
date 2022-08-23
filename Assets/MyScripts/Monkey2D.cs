///////////////////////////////////////////////////////////////////////////////////////////
///                                                                                     ///
/// Monkey2D.cs                                                                         ///
/// by Tim Ding                                                                         ///
/// hd840@nyu.edu                                                                       ///
/// For the U19 Project                                                                 ///
///                                                                                     ///
/// <summary>                                                                           ///
/// This script takes care of the stimulus behavior.                                    ///
/// Player will try to catch the FF and be given reward based on how close they are to  ///
/// the final position of the FF.                                                       ///
/// </summary>                                                                          ///
///////////////////////////////////////////////////////////////////////////////////////////

//edit
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using static JoystickMonke;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using System.IO.Ports;

public class Monkey2D : MonoBehaviour
{
    //Shared instance
    public static Monkey2D SharedMonkey;
    public GameObject firefly;
    public GameObject player;
    public ParticleSystem particle_System;
    public float p_height;

    void OnEnable()
    {
        //Run in background and clear cache
        Application.runInBackground = true;

        SharedMonkey = this;

        p_height = PlayerPrefs.GetFloat("pHeight");
    }

    void Update()
    {
        //Moves the optic flow with the player
        float EPSILON_OFFSET = 0.0002f;
        particle_System.transform.position = player.transform.position - (Vector3.up * (p_height - EPSILON_OFFSET));
    }

    public void FixedUpdate()
    {
        var keyboard = Keyboard.current;
        if (keyboard.enterKey.isPressed)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}