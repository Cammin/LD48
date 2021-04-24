using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 1;
    [SerializeField] private float _speedGainPerDepth = 0.02f;

    private float _timeSinceGameStarted;

    public static bool HasGameStarted { get; private set; }
    public static bool HasGameEnded { get; private set; }
    public static float DescendSpeed { get; private set; }
    public static float Depth { get; private set; }

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

    public static void EndGame()
    {
        HasGameEnded = true;
    }
        
    private void GameUpdate()
    {
        Depth += CalculateDownwardSpeed() * Time.deltaTime;
    }

    private float CalculateDownwardSpeed()
    {
        return _baseSpeed + _speedGainPerDepth * (Time.time - _timeSinceGameStarted);
    }
        
        
}