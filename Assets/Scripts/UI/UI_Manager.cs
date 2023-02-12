using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Score, txt_Level;
    [SerializeField] private List<GameObject> img_Health;
    [SerializeField] private TextMeshProUGUI txtMessageLevel, txtMessageScore, txtMessageHealth;
    [SerializeField] private Button btnRestart;
    private Animator lvlAnim, hpAnim;
    private int _healthIndex;

    private void Awake()
    {
        _healthIndex = 0;
        txtMessageLevel.gameObject.SetActive(false);
        txtMessageScore.gameObject.SetActive(false);
        txtMessageHealth.gameObject.SetActive(false);
        lvlAnim = txtMessageLevel.GetComponent<Animator>();
        hpAnim = txtMessageHealth.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Score_Manager.UI_Score += UI_Score_Update;
        Score_Manager.UI_Level += UI_Level_Update;
        Score_Manager.UI_Health += UI_Health_Update;
        Restart_Manager.Reset_All += RestartUI;

    }
    private void OnDisable()
    {
        Score_Manager.UI_Score -= UI_Score_Update;
        Score_Manager.UI_Level -= UI_Level_Update;
        Score_Manager.UI_Health -= UI_Health_Update;
        Restart_Manager.Reset_All -= RestartUI;
    }
    private void RestartUI()
    {
        UI_Score_Update(5);
        txt_Level.text = "1";
        Reset_Level();
    }
    private void UI_Score_Update(int _score)
    {
        txt_Score.text = _score.ToString();
        //StartCoroutine(ToggleMessage("Score",0.5f,txtMessageScore));
    }

    private void UI_Level_Update(int _level)
    { 
        txt_Level.text = _level.ToString();
        txt_Score.text = 5 + ((_level - 1) * 3) + "";
        StartCoroutine(ToggleMessage("Next Level",3f,txtMessageLevel));
        UpdateAnimationSpeed(0.7f + ((_level - 1) * 0.1f));
        print(0.7f + ((_level - 1) * 0.1f));
        Reset_Level();
    }

    private void UI_Health_Update()
    {

        img_Health[_healthIndex].SetActive(false);
        if (_healthIndex < 2)
        {
            StartCoroutine(ToggleMessage("Lost a Hat", 1f, txtMessageHealth));
            _healthIndex++;
        }
        else
        {
            StartCoroutine(ToggleMessage("Game Over", 3f, txtMessageHealth));
            btnRestart.gameObject.SetActive(true);
        }
    }
    private void Reset_Level()
    {
        _healthIndex = 0;
        foreach (GameObject img in img_Health)
        {
            img.SetActive(true);
        }
        //UI_Score_Update(0);
    }
    
    private void UpdateAnimationSpeed(float _speed)
    {
        lvlAnim.speed = _speed;
        hpAnim.speed = _speed;
    }
    IEnumerator ToggleMessage(string _txt,float _time,TextMeshProUGUI _txtHolder)
    {
        _txtHolder.text = _txt;
        _txtHolder.gameObject.SetActive(true);
        yield return new WaitForSeconds(_time);
        _txtHolder.gameObject.SetActive(false);
    }
}
