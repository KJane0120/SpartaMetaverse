using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlappyPlane_ScoreUI : FlappyPlane_BaseUI
{
    FlappyPlane_GameManager gameManager;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI isSuccessText;


    protected override UIState GetUIState()
    {
        return UIState.Score;
    }

    public override void Init(FlappyPlane_UIManager uiManager)
    {
        base.Init(uiManager);

        currentScoreText = transform.Find("CurrentScoreText").GetComponentInChildren<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponentInChildren<TextMeshProUGUI>();
        isSuccessText = transform.Find("IsSuccessText").GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateScore(int currentScore)
    {
        currentScoreText.text = currentScore.ToString();
        FlappyPlane_GameManager.Instance.bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = FlappyPlane_GameManager.Instance.bestScore.ToString();
        if (currentScore > 10)
        {
            isSuccessText.text = "You Win!";
        }
        else isSuccessText.text = "You Failed..";
    }
}
