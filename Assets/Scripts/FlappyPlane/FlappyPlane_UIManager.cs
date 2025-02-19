using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public enum UIState
{
    Home,
    Game,
    Score,

}
public class FlappyPlane_UIManager : MonoBehaviour
{
    static FlappyPlane_UIManager instance;
    public static FlappyPlane_UIManager Instance
    {
        get { return instance; }
    }

    public TextMeshProUGUI scoreText;

    UIState currentState = UIState.Home;
    FlappyPlane_HomeUI homeUI = null;
    FlappyPlane_GameUI gameUI = null;
    FlappyPlane_ScoreUI scoreUI = null;

    private void Awake()
    {
        instance = this;

        homeUI = GetComponentInChildren<FlappyPlane_HomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<FlappyPlane_GameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<FlappyPlane_ScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(UIState.Home);
        Time.timeScale = 0f;

    }
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
            Debug.LogError("score text is null");
    }

    public void SetRestart()
    {
        ChangeState(UIState.Score);
        scoreUI.UpdateScore(FlappyPlane_GameManager.Instance.currentScore);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        if (FlappyPlane_GameManager.Instance.isGameOver)
        {
            FlappyPlane_GameManager.Instance.RestartGame();
        }
        else
        {
            ChangeState(UIState.Game);
            Time.timeScale = 1.0f;
        }
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR 
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("MainScene");
        }
#else
        Application.Quit();
#endif

        }
    }
