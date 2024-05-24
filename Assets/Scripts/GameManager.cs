using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set;}
    public GameObject player;
    public PlayerGathering playerGathering;
    public SimpleJoystick joystick;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void DontDestroyOnLoad()
    {
        
    }
}
