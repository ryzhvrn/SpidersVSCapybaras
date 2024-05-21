using UnityEngine;

public class ChildCapybarasSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _childCapybaraSound;
    [SerializeField] private AudioSource _audioSource;

    private bool _isChildCapybaraDetected = false;
    private int _repeatRateForCheckChildCapybaras = 5;
    private int _repeatRateForPlayingSound = 20;
    private int _timeToStartRepeating = 0;

    private void Start()
    {
        InvokeRepeating("CheckChildCapybaraOnLevel", _timeToStartRepeating, _repeatRateForCheckChildCapybaras);
        InvokeRepeating("PlayAudioClip", _timeToStartRepeating, _repeatRateForPlayingSound);
    }

    private void CheckChildCapybaraOnLevel()
    {
        _isChildCapybaraDetected = FindObjectsOfType<ChildCapybara>().Length > 0;
    }

    private void PlayAudioClip()
    {
        if (_isChildCapybaraDetected)
        {
            _audioSource.clip = _childCapybaraSound;
            _audioSource.Play();
        }
    }
}
