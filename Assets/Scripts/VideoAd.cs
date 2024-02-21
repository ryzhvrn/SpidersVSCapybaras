using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoAd : MonoBehaviour
{
    public void ShowVideoAd() => Agava.YandexGames.VideoAd.Show(OnOpenAdCallback, OnCloseAdCallback);
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
    }

    private void OnCloseInterstitialAdCallback(bool result)
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}
