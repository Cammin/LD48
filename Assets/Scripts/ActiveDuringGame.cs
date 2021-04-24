using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDuringGame : MonoBehaviour
{
    void Update()
    {
        gameObject.SetActive(GameManager.HasGameStarted && !GameManager.HasGameEnded);
    }
}
