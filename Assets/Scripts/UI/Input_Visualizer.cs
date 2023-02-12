using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_Visualizer : MonoBehaviour
{
    [SerializeField] private Image _upArrow, _downArrow, _rightArrow, _leftArrow;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(ToggleVector(_upArrow));
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(ToggleVector(_downArrow));
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(ToggleVector(_rightArrow));
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(ToggleVector(_leftArrow));
        }
    }

    IEnumerator ToggleVector(Image _vector)
    {
        _vector.enabled = true;
        yield return new WaitForSeconds(0.2f);
        _vector.enabled = false;
    }
}
