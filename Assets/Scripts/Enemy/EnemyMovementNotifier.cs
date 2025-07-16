using Scripts.Services;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyMovementNotifier : MonoBehaviour
    {
        [SerializeField] private GameEventBus _eventBus;
    
        private bool _isMoving = false;
        private Vector3 _previousPosition;

        private void Start()
        {
            _previousPosition = transform.position;
        }

        private void Update()
        {
            bool isCurrentlyMoving = transform.position.x != _previousPosition.x;
            _isMoving = isCurrentlyMoving;
        
            _eventBus.EnemyMoving(_isMoving);
        
            _previousPosition = transform.position;
        }
    }
}
