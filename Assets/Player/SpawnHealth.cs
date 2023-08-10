using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthPrefab;
    private PlayerBehaviour _player;
    [SerializeField] private float spawnRate = 30f;
    [SerializeField] private int healthThreshold = 50;

    private void Start()
    {
        _player = GameObject.Find("PlayerRigidBody").GetComponent<PlayerBehaviour>();
        InvokeRepeating(nameof(SpawnBall), 0, spawnRate);
    }

    private void SpawnBall()
    {
        if (_player.playerHealth > healthThreshold) return;
        
        Instantiate(
            healthPrefab, 
            new Vector3(-6.5f, Random.Range(-2, 4), 0), 
            Quaternion.identity
        );
    }
}