using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bull_Manager : MonoBehaviour
{

    public static event Action Ready_Next_Move;
    public static event Action Failed_To_Counter;
    [SerializeField] AudioClip counterClip, cowMooClip,cowBellClip;
    private Transform cam;
    private bool isStarted = false;

    private void Awake()
    {
        cam = Camera.main.transform;
    }
    private void Update()
    {
        if (!isStarted && Input.anyKey)
        {
            AudioSource.PlayClipAtPoint(cowBellClip, cam.position);
            Ready_Next_Move?.Invoke();
            isStarted = true;
        }
    }
    private void OnEnable()
    {
        Bull_Forward_Anims.Bull_Forward_Countered += BullListener;
        Bull_Backward_Anims.Bull_Backward_Countered += BullListener;
        Bull_Right_Anims.Bull_Right_Countered += BullListener;
        Bull_Left_Anims.Bull_Left_Countered += BullListener;
    }
    private void OnDisable()
    {
        Bull_Forward_Anims.Bull_Forward_Countered -= BullListener;
        Bull_Backward_Anims.Bull_Backward_Countered -= BullListener;
        Bull_Right_Anims.Bull_Right_Countered -= BullListener;
        Bull_Left_Anims.Bull_Left_Countered -= BullListener;
    }
    private void BullListener(bool _countered) // after each bull move this invokes, bool _countered evals if we go on or game is over
    {
        if (_countered) // we go on
        {
            AudioSource.PlayClipAtPoint(counterClip, cam.position);
            Ready_Next_Move?.Invoke();
            //print("Forward");
        }
        else //game over
        {
            AudioSource.PlayClipAtPoint(cowMooClip, cam.position);
            Failed_To_Counter?.Invoke();
            //print("Forward_Rid");
        }
    }
}
