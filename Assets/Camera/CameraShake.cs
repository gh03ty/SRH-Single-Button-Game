using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] private PlayerBehaviour _player;

    private void OnEnable()
    {
        _player.onHit.AddListener(Shake);
    }
    
    private void Shake()
    {
        transform.DOShakePosition(0.5f, 0.5f, 10, 90, false, true);
    }

    private void OnDisable()
    {
        _player.onHit.RemoveListener(Shake);
    }
}