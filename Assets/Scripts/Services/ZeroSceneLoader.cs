using UnityEngine;

namespace Scripts.Services
{
    public sealed class ZeroSceneLoader : MonoBehaviour
    {
#if !UNITY_EDITOR && UNITY_WEBGL
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
#endif
    }
}
