using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TombStone : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        //canvas = GetComponentInChildren<Canvas>(true);
        if (canvas == null) 
            return;
        else 
            canvas.gameObject.SetActive(false);
        bestScoreText = GetComponentInChildren<TextMeshProUGUI>(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowBest();
        canvas.gameObject.SetActive(true);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canvas.gameObject.SetActive(false);
    }

    private void ShowBest()
    {
        int BestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = BestScore.ToString();
    }
}
