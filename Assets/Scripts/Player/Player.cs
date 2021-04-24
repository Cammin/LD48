using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerLight _light;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioClip _dieSound;
    [SerializeField] private Color _dieColor;
    

    public void ApplyLight(float lightAmount)
    {
        _light.IncreaseVisibility(lightAmount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.HasGameStarted || GameManager.HasGameEnded)
        {
            return;
        }
        
        if (other.gameObject.TryGetComponent(out Urchin urchin))
        {
            _movement.enabled = false;
            DeadAnim();
            
            GameManager.EndGame();
        }
    }

    private void DeadAnim()
    {
        _anim.Play("Player_Animations_Dead");
        AudioSource.PlayClipAtPoint(_dieSound, Vector3.zero);
        ParticlePool.Create(transform.position, _dieColor);
        
    }
}