using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyBehavior : MonoBehaviour
    {
        private float _directionFloat;
        private Rigidbody _player;
        private int difficulty;
    
        private void Start()
        {
            _player = GameObject.Find("PlayerRigidBody").GetComponent<Rigidbody>();
            
            InvokeRepeating(
                nameof(GetPlayerPos), 5, 1f);
        }

        private void GetPlayerPos()
        {
            _directionFloat = Mathf.Clamp(
                _player.transform.position.y + Random.Range(-2f,2f),
                -3, 
                6
            );
        }
    
        private void Update()
        {
            var position = transform.position;
            var newPosition = position;
            newPosition.y = _directionFloat;
        
            position = Vector3.MoveTowards(
                position, 
                newPosition, 
                Time.deltaTime * 10);
        
            transform.position = position;
        }
    }
}
