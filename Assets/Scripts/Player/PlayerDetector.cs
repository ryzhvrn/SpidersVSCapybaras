using Scripts.Services;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private GameEventBus _eventBus;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                _eventBus.PlayerDetected();
            }
        }
    }
}