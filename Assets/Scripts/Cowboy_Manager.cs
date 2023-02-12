using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy_Manager : MonoBehaviour
{
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        Score_Manager.Game_Over += CowboyFall;
        Restart_Manager.Reset_All += ResetCowboy;
    }
    private void OnDisable()
    {
        Score_Manager.Game_Over -= CowboyFall;
        Restart_Manager.Reset_All -= ResetCowboy;
    }

    private void CowboyFall()
    {
        rb.isKinematic = false;
    }
    private void ResetCowboy()
    {
        rb.isKinematic = true;
        transform.SetLocalPositionAndRotation(Vector3.zero, new Quaternion(0, 0, 0, 0));
    }
}
