using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    private Difficulty _difficulty;
    [SerializeField] private Transform _progressBar;
    
    private void Start()
    {
        _difficulty = FindObjectOfType<Difficulty>();
    }

    void Update()
    {
        var progress = Mathf.Clamp01(Time.timeSinceLevelLoad /_difficulty.gameLength);
        _progressBar.transform.localScale = new Vector3(progress, 1, 1);
    }
}
