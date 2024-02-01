using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public sealed class ZeroSceneLoader : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnInitialized);
    }

    private void OnInitialized()
    {
        StarterScene.Load();
    }
}
