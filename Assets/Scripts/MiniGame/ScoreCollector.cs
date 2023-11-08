using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCollector : MonoBehaviour
{
    public float score;
    TextMeshProUGUI textScore;

    private void Awake()
    {
        score = 0f;
    }

    private void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        ScoreAdd();
    }

    public void ScoreAdd()
    {
        textScore.text = score.ToString();
    }
}
