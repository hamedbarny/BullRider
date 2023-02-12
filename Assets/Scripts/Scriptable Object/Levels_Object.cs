using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_Data", menuName = "Level Data/Levels")]

public class Levels_Object : ScriptableObject
{
    public string _description;
    public int _levelCap;
    public int _chances;
    public float _speed;

}
