using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Restart_Manager : MonoBehaviour
{
    public static event Action Reset_All;

    public void RestartGame()
    {
        Reset_All?.Invoke();
    }
}
