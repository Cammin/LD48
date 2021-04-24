using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private const string KEY = "<d>";
        
    [SerializeField] private TextMeshProUGUI _depthText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private string _formerDepthText;
    private string _formerHighScoreText;
    
    private void Awake()
    {
        _formerDepthText = _depthText.text;
        _formerHighScoreText = _highScoreText.text;
    }

    public void SetDepthText(float depth)
    {
        string depthString = depth.ToString("F1");
        _depthText.text = _formerDepthText.Replace(KEY, depthString);
    }

    public void SetHighScoreText(float highScore)
    {
        string highScoreString = highScore.ToString("F1");
        _highScoreText.text = _formerHighScoreText.Replace(KEY, highScoreString);
    }
}