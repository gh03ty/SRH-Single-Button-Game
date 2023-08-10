using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class ShootingBehavior : MonoBehaviour
    {
        [SerializeField] private GameObject[] bulletPrefabs;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float initialShootingRate = 1.25f;
        [SerializeField] private float currentShootingRate;
        [SerializeField] private ParticleSystem shootEffect;
        [SerializeField] private AudioSource shootSound;
        [SerializeField] private float initialWaitTime = 5f;

        private Difficulty _difficulty;
        private float _timePassed;
        private bool _waiting = true;

        private void Start()
        {
            currentShootingRate = initialShootingRate;
        }

        private void OnEnable()
        {
            _difficulty = GameObject.Find("Difficulty").GetComponent<Difficulty>();
            _difficulty.onDifficultyIncrease.AddListener(UpdateShootingRate);
        }

        private void OnDisable()
        {
            _difficulty.onDifficultyIncrease.RemoveListener(UpdateShootingRate);
        }

        private void UpdateShootingRate()
        {
            currentShootingRate = initialShootingRate - (0.15f * _difficulty.difficulty);
        }

        private void Shoot()
        {
            GameObject bulletPrefab = bulletPrefabs[Random.Range(0, bulletPrefabs.Length + (_difficulty.difficulty - _difficulty.difficultyLimit))];
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            float bulletForce = bullet.GetComponent<BulletBehaviour>().force;
            shootEffect.Play();
            shootSound.Play();
            bulletRigidbody.AddForce(Vector3.left * bulletForce, ForceMode.Impulse);
        }

        private void Update()
        {
            if (_waiting)
            {
                _timePassed += Time.deltaTime;
                if (_timePassed < initialWaitTime)
                    return;
                _waiting = false;
                _timePassed = 0;
            }

            _timePassed += Time.deltaTime;
            if (_timePassed > currentShootingRate)
            {
                _timePassed = 0;
                Shoot();
            }
        }
    }
}