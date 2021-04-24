using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private const string KEY = "<d>";
        
    [SerializeField] private TextMeshProUGUI _depthText;
        
    public void SetDepthText(float depth)
    {
        string depthString = depth.ToString("F1");

        _depthText.text = _depthText.text.Replace(KEY, depthString);
    }
}