using UnityEngine;

public class Timer
{
    private float _endTime;
    
    public void Set(float time)
    {
        _endTime = Time.time + time;
    }

    public bool IsRunning => Time.time < _endTime;
}