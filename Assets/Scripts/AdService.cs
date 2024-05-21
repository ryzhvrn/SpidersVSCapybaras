using System;
using UnityEngine;

public class AdService
{
    public static event Action CollectingVideoAdReward;
    public static event Action ShowingInteractiveElements;

    public void ShowVideoAd() => Agava.YandexGames.VideoAd.Show(OnOpenAdCallback, OnRewardedCallback, OnCloseAdCallback);
    public void ShowInterstitialAd() => Agava.YandexGames.InterstitialAd.Show(OnOpenAdCallback, OnCloseInterstitialAdCallback);

    private void OnOpenAdCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnCloseAdCallback()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
        ShowingInteractiveElements?.Invoke();
    }

    private void OnRewardedCallback()
    {
        CollectingVideoAdReward?.Invoke();
    }

    private void OnCloseInterstitialAdCallback(bool result)
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
        ShowingInteractiveElements?.Invoke();
    }
}
