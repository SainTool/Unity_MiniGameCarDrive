using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI field;
    private int score = 0;
    public float timeSC = 1f;
    private float timeStart;
    private CarController carControllerSc;

    private void Awake()
    {
        field = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        carControllerSc = GameObject.Find("Car").GetComponent<CarController>();
        field.text = score.ToString();
        timeStart = timeSC;
    }

    private void Update()
    { 
        if (timeSC < 0 && !carControllerSc.gameOver)
        {
            score += 1;
            timeSC = timeStart;
        }
        else
        {
            timeSC -= 0.1f;
        }
        field.text = score.ToString();
    }
}
