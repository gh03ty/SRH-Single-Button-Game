using System;
using UnityEngine;


public class WaveBehaviour : MonoBehaviour
{
    private Transform _bulletTransform;
    private float _localY;

    void Start()
    {
        _bulletTransform = gameObject.transform;
        _localY = transform.position.y;
    }

    private void Update()
    {
        var bulletPos = _bulletTransform.position;
        var newPos = bulletPos;
        newPos.y = (float)Math.Sin(Math.PI * (newPos.x + 20f * Time.deltaTime)) + _localY;
        _bulletTransform.position = Vector3.MoveTowards(
            bulletPos, 
            newPos, 
            Time.deltaTime * 8);
    }
}