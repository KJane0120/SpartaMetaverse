using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlane_GameManager : MonoBehaviour
{
    static FlappyPlane_GameManager gameManager;
    public static FlappyPlane_GameManager Instance { get { return gameManager; } }

    public int currentScore = 0;
    public int bestScore = 0;

    FlappyPlane_UIManager uiManager;
    public FlappyPlane_UIManager UIManager { get { return uiManager; } }

    public bool isGameOver = true;

    public int SaveBestScore(int currentScore)
    {
        // ���� �ְ� ������ �ҷ��� (������ 0)
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        // ���� ������ �ְ� �������� ������ ����
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save(); // ���� ������ ��� ����
        }

        return bestScore;
    }


    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<FlappyPlane_UIManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        uiManager.UpdateScore(0);
        isGameOver = false;
    }



    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game over");
        uiManager.SetRestart();

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentScore = 0;
        uiManager.UpdateScore(0);

    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
