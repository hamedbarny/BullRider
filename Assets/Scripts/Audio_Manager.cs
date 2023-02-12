using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    private AudioSource audioS;
    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        Score_Manager.UI_Level += ChangePitch;
    }
    private void OnDisable()
    {
        Score_Manager.UI_Level -= ChangePitch;
    }
    private void ChangePitch(int _level)
    {
        audioS.pitch = 0.99f + (_level * 0.01f);
    }

}
