using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HitEffect : MonoBehaviour
{

    [SerializeField] private PlayerBehaviour _player;
    private MeshRenderer _meshRenderer;
    [SerializeField] private float duration = 1f;
    
    void Awake()
    { 
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _player.onHit.AddListener(Flash);
    }
    
    private void Flash()
    {
        _meshRenderer.material.DOColor(Color.red, duration / 2).OnComplete(() =>
        {
            _meshRenderer.material.DOColor(Color.white, duration / 2);
        });
    }
    
    private void OnDisable()
    {
        _player.onHit.RemoveListener(Flash);
    }
}