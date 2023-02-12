using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bull_Left_Anims : StateMachineBehaviour
{
    public static event Action<bool> Bull_Left_Countered;
    bool canCounter;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        canCounter = true;
        //animator.SetInteger(Bull_Movement.moveState, 0);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (canCounter && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            Bull_Left_Countered?.Invoke(true);
            canCounter = false;
        }
        if (canCounter && (Input.GetKeyDown(KeyCode.A)
                        || Input.GetKeyDown(KeyCode.S)
                        || Input.GetKeyDown(KeyCode.W)
                        || Input.GetKeyDown(KeyCode.DownArrow)
                        || Input.GetKeyDown(KeyCode.LeftArrow)
                        || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Bull_Left_Countered?.Invoke(false);
            canCounter = false;
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (canCounter) Bull_Left_Countered?.Invoke(false);
    }
}
