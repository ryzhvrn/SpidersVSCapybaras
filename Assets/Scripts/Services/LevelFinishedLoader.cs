using System;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinishedLoader : MonoBehaviour
{
    [SerializeField] private Image[] _starsEarnedImages;
    [SerializeField] private Text _zeroStarsEarnedWarning;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _levelsMenuButton;
    
    private AdService _ads = new AdService();

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _restartButton.gameObject.SetActive(false);
        _levelsMenuButton.gameObject.SetActive(false);
        Invoke("ShowInterstitialAd", 2f);
#endif

        SetCurrentLevelResult(GetCurrentLevelProgress());
    }

    private void OnEnable()
    {
        _ads.ShowingInteractiveElements += OnShowInteractiveElements;
    }

    private void OnDisable()
    {
        _ads.ShowingInteractiveElements -= OnShowInteractiveElements;
    }

    private void ShowInterstitialAd()
    {
        _ads.ShowInterstitialAd();
    }

    private int GetCurrentLevelProgress()
    {
        string previousScene = PlayerPrefs.GetString("PreviousScene");
        int currentProgress = PlayerPrefs.GetInt(previousScene);

        return currentProgress;
    }

    private void OnShowInteractiveElements()
    {
        _restartButton.gameObject.SetActive(true);
        _levelsMenuButton.gameObject.SetActive(true);
    }

    private void SetCurrentLevelResult(int starsEarnedAmount)
    {
        for (int i = 0; i < _starsEarnedImages.Length; i++)
        {
            _starsEarnedImages[i].gameObject.SetActive(i < starsEarnedAmount);
        }

        _zeroStarsEarnedWarning.gameObject.SetActive(starsEarnedAmount == 0);
    }
}
