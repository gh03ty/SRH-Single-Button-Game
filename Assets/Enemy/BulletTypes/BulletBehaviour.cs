using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float force = 1f;
    public float ttl = 5f;
    public int damage = 10;
    
    void Start()
    {
        Destroy(gameObject, ttl);
    }
    
    private void OnTriggerEnter(Collider pCollider)
    {
        var playerBehaviour = pCollider.GetComponent<PlayerBehaviour>();
        if (playerBehaviour == null) return;
        playerBehaviour.GetDamage(damage);
        Destroy(gameObject);
    }
}