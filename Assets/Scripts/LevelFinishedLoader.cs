using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;
using System;

public class LevelFinishedLoader : MonoBehaviour, ISceneLoadHandler<LevelConfig>
{
    [SerializeField] private Image ThreeStarsEarned;
    [SerializeField] private Image TwoStarsEarned;
    [SerializeField] private Image OneStarsEarned;
    [SerializeField] private Text ZeroStarsEarnedWarning;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _levelsMenuButton;
    private AdService _ads = new AdService();

    public static event Action SetPlayerScore;

    private void Awake()
    {
        _restartButton.gameObject.SetActive(false);
        _levelsMenuButton.gameObject.SetActive(false);
        Invoke("ShowInterstitialAd", 2f);
    }

    private void OnEnable()
    {
        AdService.ShowInteractiveElements += OnShowInteractiveElements;
    }

    private void OnDisable()
    {
        AdService.ShowInteractiveElements -= OnShowInteractiveElements;
    }

    public void OnSceneLoaded(LevelConfig argument)
    {
        int starsEarnedAmount = argument.StarsEarned;
        SetCurrentLevelResul(starsEarnedAmount);
        SetPlayerScore?.Invoke();
    }

    private void ShowInterstitialAd()
    {
        _ads.ShowInterstitialAd();
    }

    private void OnShowInteractiveElements()
    {
        _restartButton.gameObject.SetActive(true);
        _levelsMenuButton.gameObject.SetActive(true);
    }

    private void SetCurrentLevelResul(int starsEarnedAmount)
    {
        if (starsEarnedAmount == 3)
        {
            OneStarsEarned.gameObject.SetActive(true);
            TwoStarsEarned.gameObject.SetActive(true);
            ThreeStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 2)
        {
            OneStarsEarned.gameObject.SetActive(true);
            TwoStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 1)
        {
            OneStarsEarned.gameObject.SetActive(true);
        }
        else if (starsEarnedAmount == 0)
        {
            ZeroStarsEarnedWarning.gameObject.SetActive(true);
        }
    }
}
