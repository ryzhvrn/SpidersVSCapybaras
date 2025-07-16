using UnityEngine;

namespace Scripts.Player
{
    public class PlayerAudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip _playerRunningSound;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ThirdPersonMovementController _controller;

        private bool _isPlaying = false;

        private void OnEnable()
        {
            _controller.PlayerMoving += OnPlayerMoving;
        }

        private void OnDisable()
        {
            _controller.PlayerMoving -= OnPlayerMoving;
        }

        private void OnPlayerMoving(bool isRunning)
        {
            if (isRunning && _isPlaying == false)
            {
                _audioSource.clip = _playerRunningSound;
                _audioSource.Play();
                _isPlaying = _audioSource.isPlaying;
            }

            if (isRunning == false)
            {
                _audioSource.Stop();
                _isPlaying = false;
            }
        }
    }
}
