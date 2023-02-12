using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score_Manager : MonoBehaviour
{
    public static event Action Game_Over, UI_Health , Level_Uped;
    public static event Action<int> UI_Level, UI_Score;
    [SerializeField] private Levels_Object levels_SO;
    [SerializeField] private AudioClip cowBellClip;
    private int _chances, _score, thisLevelScore, _currentLevel;
    private Animator _animator;
    float startSpeed;
    Transform cam;

    private void OnEnable()
    {
        Bull_Manager.Failed_To_Counter += Chance_Left;
        Bull_Manager.Ready_Next_Move += Count_Score;
        Restart_Manager.Reset_All += Start_Level;
    }
    private void OnDisable()
    {
        Bull_Manager.Failed_To_Counter -= Chance_Left;
        Bull_Manager.Ready_Next_Move -= Count_Score;
        Restart_Manager.Reset_All -= Start_Level;

    }
    private void Awake()
    {
        cam = Camera.main.transform;
        _animator = GetComponent<Animator>();
        startSpeed = _animator.speed;
        Start_Level();
    }
    private void Start_Level() // at start reset values
    {
        _currentLevel = 1;
        _score = 5;
        _chances = 3;
        thisLevelScore = 5;
        _animator.speed = startSpeed;
        UI_Level?.Invoke(_currentLevel);
    }
    private void Level_Up() // every level up => variables + base level up
    {
        _currentLevel++;
        AudioSource.PlayClipAtPoint(cowBellClip, cam.position);
        UI_Level?.Invoke(_currentLevel);
        _chances = levels_SO._chances;
        thisLevelScore += levels_SO._levelCap;
        _animator.speed += levels_SO._speed;
        _score = thisLevelScore;
    }

    private void Chance_Left() // counts the life/chances left after each failer
    {
        _chances--;
        if (_chances <= 0)
        {
            Game_Over?.Invoke();
        }
         UI_Health.Invoke();
    }
    private void Count_Score() // increment score after succesful counters
    {
        _score--;
        UI_Score?.Invoke(_score);
        if(_score <= 0) // level up
        {
            Level_Up();
            Level_Uped?.Invoke();
        }
    }
}
