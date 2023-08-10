using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    private PlayerBehaviour _playerBehaviour;
    private Rigidbody _rigidbody;
    
    void Start()
    {
        var player = GameObject.Find("PlayerRigidBody");
        _playerBehaviour = player.GetComponent<PlayerBehaviour>();
        _rigidbody = player.GetComponent<Rigidbody>();
        _playerBehaviour.enabled = true;
        _rigidbody.useGravity = true;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _playerBehaviour.enabled = true;
            _rigidbody.useGravity = true;
            Destroy(this);
        }
    }
}
