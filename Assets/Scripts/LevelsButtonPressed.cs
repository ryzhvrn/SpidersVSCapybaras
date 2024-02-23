using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButtonPressed : MonoBehaviour
{
    public static event Action LevelsSceneActivated;

    private AdService _ads = new AdService();

    public void OnLevelsMenuButtonPressed()
    {
        LevelsSceneActivated?.Invoke();
        ShowAdOnLevelToLevelsMenuTransition();
    }

    private void ShowAdOnLevelToLevelsMenuTransition()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        switch (currentSceneName)
        {
            case "Level1":
                _ads.ShowInterstitialAd();
                break;
            case "Level2":
                _ads.ShowInterstitialAd();
                break;
            case "Level3":
                _ads.ShowInterstitialAd();
                break;
            default:
                break;
        }
    }
}
