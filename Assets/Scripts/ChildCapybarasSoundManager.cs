using UnityEngine;

public class ChildCapybarasSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _childCapybaraSound;
    [SerializeField] private AudioSource _audioSource;

    private bool _isChildCapybaraDetected = false;

    private void Start()
    {
        InvokeRepeating("CheckChildCapybaraOnLevel", 0, 5);
        InvokeRepeating("PlayAudioClip", 0, 20);
    }

    private void CheckChildCapybaraOnLevel()
    {
        ChildCapybara[] foundChildCapybara = FindObjectsOfType<ChildCapybara>();

        if (foundChildCapybara.Length > 0)
        {
            _isChildCapybaraDetected = true;
        }
        else
        {
            _isChildCapybaraDetected = false;
        }
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
