using UnityEngine;
using Agava.WebUtility;

public class FocusMonitoring : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    private void MuteAudio(bool value)
    {
        _audioSource.volume = value ? 0 : 1;
        AudioListener.volume = value ? 0 : 1;
        AudioListener.pause = value;

        if (!value && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? 1 : 0;
    }

    private void OnInBackgroundChangeWeb(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeApp(bool isBackground)
    {
        MuteAudio(!isBackground);
        PauseGame(isBackground);
    }
}
