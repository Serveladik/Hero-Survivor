using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set;}
    public SimpleJoystick joystick;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
