using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlane_GameManager : MonoBehaviour
{
    static FlappyPlane_GameManager gameManager;
    public static FlappyPlane_GameManager Instance { get { return gameManager; } }

    public int currentScore = 0;

    FlappyPlane_UIManager uiManager;
    public FlappyPlane_UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<FlappyPlane_UIManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
