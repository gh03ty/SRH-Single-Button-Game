using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBehaviour : MonoBehaviour
{
    private Difficulty _difficulty;
    
    void Start()
    {
        _difficulty = FindObjectOfType<Difficulty>();
    }
    
    void Update()
    {
        if (Time.timeSinceLevelLoad >= _difficulty.gameLength)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
