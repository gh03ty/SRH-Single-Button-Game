using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody rigidBody;
    public int playerHealth = 100;
    public UnityEvent onHit;
    public UnityEvent onHeal;
    public ParticleSystem damageParticleSystem;
    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip healSound;
    public AudioClip deathSound;
    public AudioClip thrusterSound;
    private readonly float _heightThreshold = 5.5f;

    private void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public void GetDamage(int damage)
    {
        if (playerHealth <= 0) return;
        PlayHitSound();
        playerHealth -= damage;
        onHit?.Invoke();
        damageParticleSystem.Play();
    }

    private void PlayHitSound()
    {
        audioSource.clip = hitSound;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
    
    private void PlayHealSound()
    {
        audioSource.clip = healSound;
        audioSource.volume = 0.8f;
        audioSource.Play();
    }
    
    public void GetHeal(int healAmount)
    {
        if (playerHealth <= 0 && playerHealth >= 100) return;
        playerHealth = Mathf.Clamp(playerHealth + healAmount, 0, 100);
        PlayHealSound();
        onHeal?.Invoke();
    }

    private void MovePlayerUp()
    {
        if (playerTransform.position.y > _heightThreshold)
        {
            rigidBody.velocity = Vector3.zero;
            return;
        }
        
        if (!Input.GetKey(KeyCode.Space)) return;
        if (rigidBody.velocity.y < 0) rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce(Vector3.up * (1000 * Time.deltaTime), ForceMode.Acceleration);
    }

    private void MovePlayerDown()
    {
        var velocityNorm = Mathf.Clamp(rigidBody.velocity.y, -1, 1);
        playerTransform.rotation = Quaternion.Euler(-velocityNorm * 15, 90, 0);
    }
    
    private void Update()
    {
        MovePlayerUp();
        MovePlayerDown();
    }
}