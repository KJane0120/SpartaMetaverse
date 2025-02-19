using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }

    protected int currentScore = 0;

    protected virtual void Awake()
    {
        gameManager = this;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void GameOver()
    {
        Debug.Log("Game over");
    }

    protected virtual void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected virtual void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
    }
}
