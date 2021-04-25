using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private InputActionReference _playAction;
        [SerializeField] private InputActionReference _quitAction;

        private void OnEnable()
        {
            _playAction.action.Enable();
            _playAction.action.started += StartGame;
            
            _quitAction.action.Enable();
            _quitAction.action.started += Quit;
        }

        private void OnDisable()
        {
            _playAction.action.Disable();
            _playAction.action.started -= StartGame;
            
            _quitAction.action.Disable();
            _quitAction.action.started -= Quit;
        }

        private void StartGame(InputAction.CallbackContext obj)
        {
            SceneUtil.ToGame();
        }

        private void Quit(InputAction.CallbackContext obj)
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                return;
            }
            Application.Quit();
        }
        
    }
}