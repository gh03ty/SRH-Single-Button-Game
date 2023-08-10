using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailBehaviour : MonoBehaviour
{
    private PlayerBehaviour _player;
    
    void Start()
    {
        _player = FindObjectOfType<PlayerBehaviour>();
    }
    
    void Update()
    {
        if (_player.playerHealth <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
    }
}
