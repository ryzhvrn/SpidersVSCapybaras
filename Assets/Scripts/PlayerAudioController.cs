using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _playerRunningSound;
    [SerializeField] private AudioSource _audioSource;

    private bool _isPlaying = false;

    private void OnEnable()
    {
        ThirdPersonMovementController.PlayerMoving += OnPlayerMoving;
    }

    private void OnDisable()
    {
        ThirdPersonMovementController.PlayerMoving -= OnPlayerMoving;
    }

    private void OnPlayerMoving(bool isRunning)
    {
        if (isRunning == true && _isPlaying == false)
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
