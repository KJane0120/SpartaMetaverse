using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlappyPlane_ScoreUI : FlappyPlane_BaseUI
{

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    

    protected override UIState GetUIState()
    {
        return UIState.Score;
    }

    public override void Init(FlappyPlane_UIManager uiManager)
    {
        base.Init(uiManager);

        currentScoreText = transform.Find("CurrentScoreText").GetComponentInChildren<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateScore(int currentScore)
    {
        currentScoreText.text = currentScore.ToString();
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = bestScore.ToString();
    }
}
