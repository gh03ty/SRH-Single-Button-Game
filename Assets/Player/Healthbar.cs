using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private PlayerBehaviour _playerBehaviour;
    
    void Start()
    {
        _playerBehaviour = GetComponent<PlayerBehaviour>();
        _playerBehaviour.onHit.AddListener(UpdateHealthBar);
        _playerBehaviour.onHeal.AddListener(UpdateHealthBar);
        healthBar.transform.localScale = new Vector3(11, 1, 1);
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3(
            _playerBehaviour.playerHealth / 10, 
            1, 
            1
        );
    }
}