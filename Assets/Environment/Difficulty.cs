using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Difficulty : MonoBehaviour
{
    public int difficulty = 1;
    public int difficultyLimit = 3;
    public float gameLength = 180f;
    public float waveLength;
    public UnityEvent onDifficultyIncrease;

    void Start()
    {
        waveLength = gameLength / difficultyLimit;
        InvokeRepeating(nameof(IncreaseDifficulty), waveLength, waveLength);
    }

    private void IncreaseDifficulty()
    {
        if (difficulty >= difficultyLimit || !(Time.timeSinceLevelLoad < gameLength)) return;
        onDifficultyIncrease?.Invoke();
        difficulty++;
    }
}
