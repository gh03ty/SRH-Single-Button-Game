using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSphereBehavior : MonoBehaviour
{
    [SerializeField] private int healAmount = 50;
    
    private void OnTriggerEnter(Collider pCollider)
    {
        var playerBehaviour = pCollider.GetComponent<PlayerBehaviour>();
        if (playerBehaviour == null) return;
        playerBehaviour.GetHeal(healAmount);
        Destroy(gameObject);
    }
}