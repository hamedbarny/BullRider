using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull_Movement : MonoBehaviour
{
    Animator _animator;
    public static int moveState;
    private void Awake()
    {
        moveState = Animator.StringToHash("WhichWay");
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Bull_Manager.Ready_Next_Move += GenerateNextMove;
        Score_Manager.Game_Over += GameOver;
        Score_Manager.Level_Uped += GetReadyForNextLevel;
        Restart_Manager.Reset_All += GetReadyForNextLevel;
    }
    private void OnDisable()
    {
        Bull_Manager.Ready_Next_Move -= GenerateNextMove;
        Score_Manager.Game_Over -= GameOver;
        Score_Manager.Level_Uped -= GetReadyForNextLevel;
        Restart_Manager.Reset_All -= GetReadyForNextLevel;
    }
    private void GenerateNextMove() // generates randome bull move [1=>forward , 2=>backward , 3=>right , 4=>left]
    {
        int randVal = Random.Range(1, 5);
        _animator.SetInteger(moveState, randVal);
    }
    private void GameOver() //Failed to counter bull moves
    {
        _animator.SetInteger(moveState, 0);
    }
    private void GetReadyForNextLevel() // actions between levels/ after each level up/ time to rest player
    {
        GameOver();
        StartCoroutine(StartAgain());
    }

    IEnumerator StartAgain()
    {
        yield return new WaitForSeconds(3);
        GenerateNextMove();
    }
}
