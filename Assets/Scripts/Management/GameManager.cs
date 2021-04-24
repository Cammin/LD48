using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private UIManager _ui;
    
    [SerializeField] private float _baseSpeed = 1;
    [SerializeField] private float _speedGainPerDepth = 0.02f;

    private float _timeSinceGameStarted;

    private bool _hasGameStarted;
    private bool _hasGameEnded;
    
    
    public static bool HasGameStarted { get; private set; }
    public static bool HasGameEnded { get; private set; }
    public static float DescendSpeed { get; private set; }
    public static float Depth { get; private set; }
    public static float HighScore { get; private set; }

    


    public void Start()
    {
        StartGame();
    }

    private void Update()
    {
        GameUpdate();
    }

    public void StartGame()
    {
        _timeSinceGameStarted = Time.time;
        HasGameStarted = true;
    }

    public void EndGame()
    {
        HasGameEnded = true;
    }
        
    private void GameUpdate()
    {
        Depth += CalculateDownwardSpeed() * Time.deltaTime;
        
        //update UI
        _ui.SetDepthText(Depth);
    }

    private float CalculateDownwardSpeed()
    {
        return _baseSpeed + _speedGainPerDepth * (Time.time - _timeSinceGameStarted);
    }
        
        
}