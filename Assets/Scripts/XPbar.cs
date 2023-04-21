using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbar : MonoBehaviour
{
    [SerializeField]
    ScoreXp scoreXp;
    [SerializeField]
    Text score;
    [SerializeField]
    Text healthscore;

    public Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();

    }

    private void OnEnable()
    {
        slider.value = scoreXp.score % slider.maxValue;
        var level = (scoreXp.score / (int)slider.maxValue);
        score.text = level.ToString();
        healthscore.text = (level *20).ToString();
    }
}
