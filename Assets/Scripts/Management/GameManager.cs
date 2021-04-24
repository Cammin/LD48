using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    private const string HIGH_SCORE = "KEY_HIGHSCORE";

    [SerializeField] private InputActionReference _action;
    [SerializeField] private UIManager _ui;
    [SerializeField] private AudioSource _musicPlayer;
    
    [SerializeField] private float _baseSpeed = 1;
    [SerializeField] private float _speedGainPerDepth = 0.02f;

    private float _timeSinceGameStarted;
    
    
    public static bool HasGameStarted { get; private set; }
    public static bool HasGameEnded { get; private set; }
    public static float DescendSpeed { get; private set; }
    public float Depth { get; private set; }
    public static float HighScore { get; private set; }


    protected override void ResetStatics()
    {
        HasGameStarted = false;
        HasGameEnded = false;
        DescendSpeed = 0;
        Depth = 0;
        HighScore = 0;
    }

    private void Awake()
    {
        ResetStatics();
        HighScore = PlayerPrefs.GetFloat(HIGH_SCORE, 0);
    }

    public void Start()
    {
        //start game after cutscene
        _action.action.Enable();
        StartGame();
    }

    private void Update()
    {
        
        if (!HasGameStarted)
        {
            return;
        }

        if (HasGameEnded)
        {
            if (_action.action.triggered)
            {
                SceneUtil.RestartScene();
            }

            return;
        }
        
        GameUpdate();
    }

    public void StartGame()
    {
        _timeSinceGameStarted = Time.time;
        HasGameStarted = true;
    }

    public static void EndGame()
    {
        Instance._musicPlayer.Stop();
        Instance._ui.GameOver();
        Debug.Log("GAME OVER");
        HasGameEnded = true;
        PlayerPrefs.Save();
    }
        
    private void GameUpdate()
    {
        DescendSpeed = CalculateDownwardSpeed();
        Depth += DescendSpeed * Time.deltaTime;

        HighScore = Mathf.Max(HighScore, Depth);
        PlayerPrefs.SetFloat(HIGH_SCORE, HighScore);
        
        //update UI
        _ui.SetDepthText(Depth);
        _ui.SetHighScoreText(HighScore);
    }

    private float CalculateDownwardSpeed()
    {
        return _baseSpeed + _speedGainPerDepth * (Time.time - _timeSinceGameStarted);
    }
        
        
}