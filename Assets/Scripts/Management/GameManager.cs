using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    private const string HIGH_SCORE = "KEY_HIGHSCORE";

    [SerializeField] private InputActionReference _action;
    [SerializeField] private InputActionReference _quit;
    [SerializeField] private UIManager _ui;
    [SerializeField] private AudioSource _musicPlayer;
    
    [SerializeField] private float _depthScoreFactor = 0.5f;
    [SerializeField] private float _baseSpeed = 1;
    [SerializeField] private float _speedGainPerDepth = 0.02f;

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
        
        
        StartGame();
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        
        _action.action.Enable();
        _quit.action.Enable();
        
        _action.action.started += TryRestartGame;
        _quit.action.started += TryQuitGame;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        
        _action.action.Disable();
        _quit.action.Disable();
        
        _action.action.started -= TryRestartGame;
        _quit.action.started -= TryQuitGame;
    }


    private void TryRestartGame(InputAction.CallbackContext obj)
    {
        Debug.Log("Button Pressed");
        if (HasGameEnded)
        {
            SceneUtil.RestartScene();
        }
    }
    private void TryQuitGame(InputAction.CallbackContext obj)
    {
        Debug.Log("Button Pressed");

            SceneUtil.ToMainMenu();
        
    }

    private void Update()
    {
        
        if (!HasGameStarted || HasGameEnded)
        {
            return;
        }

       
        
        GameUpdate();
    }

    public void StartGame()
    {
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
        Depth += DescendSpeed * Time.deltaTime * _depthScoreFactor;

        HighScore = Mathf.Max(HighScore, Depth);
        PlayerPrefs.SetFloat(HIGH_SCORE, HighScore);
        
        //update UI
        _ui.SetDepthText(Depth);
        _ui.SetHighScoreText(HighScore);
    }

    private float CalculateDownwardSpeed()
    {
        return _baseSpeed + _speedGainPerDepth * (Time.timeSinceLevelLoad);
    }
        
        
}