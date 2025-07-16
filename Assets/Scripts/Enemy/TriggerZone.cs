using Scripts.Capybaras;
using Scripts.Services;
using UnityEngine;

namespace Scripts.Enemy
{
    public class TriggerZone : MonoBehaviour
    {
        [SerializeField] private GameEventBus _eventBus;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Capy capy))
            {
                _eventBus.TriggerZoneEntered(capy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Capy capy))
            {
                _eventBus.TriggerZoneLeft(capy);
            }
        }
    }
}