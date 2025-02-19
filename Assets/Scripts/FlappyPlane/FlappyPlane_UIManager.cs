using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;


public enum UIState
{
    Home,
    Game,
    Score

}
public class FlappyPlane_UIManager : MonoBehaviour
{
    static FlappyPlane_UIManager instance;
    public static FlappyPlane_UIManager Instance
    {
        get { return instance; }
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    UIState currentState = UIState.Home;
    FlappyPlane_HomeUI homeUI = null;
    FlappyPlane_GameUI gameUI = null;
    //ScoreUI scoreUI = null;

    private void Awake()
    {
        instance = this;

        homeUI = GetComponentInChildren<FlappyPlane_HomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<FlappyPlane_GameUI>(true);
        gameUI?.Init(this);

        //scoreUI = GetComponentInChildren<ScoreUI>(true);
        //scoreUI?.Init(this);

        ChangeState(UIState.Home);
        Time.timeScale = 0f;

    }
    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.LogError("restart text is null");
        if (scoreText == null)
            Debug.LogError("score text is null");
        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
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
        //scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        ChangeState(UIState.Game);
        Time.timeScale = 1.0f;
        //startgame() 게임 초반 초기화 해주는 함수 호출
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
