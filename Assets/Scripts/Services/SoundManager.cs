using UnityEngine;

namespace Scripts.Services
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _sceneLevelLoadSound;

        private void Start()
        {
            AudioSource.PlayClipAtPoint(_sceneLevelLoadSound, transform.position);
        }
    }
}
