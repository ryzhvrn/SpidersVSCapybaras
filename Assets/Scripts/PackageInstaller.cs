#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class PackageInstaller : MonoBehaviour
{
    private static string[] _packageUrls = {
        "https://github.com/forcepusher/com.agava.yandexgames.git#13.2.0",
        "https://github.com/forcepusher/com.agava.webutility.git#3.0.0",
        "https://github.com/forcepusher/com.agava.yandexmetrica.git#1.2.0"
    };

    private static int _currentIndex = 0;

    [MenuItem("Installer/Initialize Project")]
    public static void InitializeProject()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);
        PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.WebGL, false);
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Brotli;
        PlayerSettings.WebGL.nameFilesAsHashes = true;
        PlayerSettings.WebGL.dataCaching = false;
        PlayerSettings.WebGL.decompressionFallback = true;
        Application.runInBackground = true;
        PlayerSettings.WebGL.template = "FullscreenWindow";
        AddSceneInitialized();

        Debug.Log("WebGL project settings initialization completed.");
    }

    [MenuItem("Installer/Install Package from YandexSDK")]
    public static void InstallPackageYandexSDK()
    {
        InstallPackage("https://github.com/forcepusher/com.agava.yandexgames.git#13.2.0");
    }

    [MenuItem("Installer/Install Package from WebUtility")]
    public static void InstallPackageWebUtility()
    {
        InstallPackage("https://github.com/forcepusher/com.agava.webutility.git#3.0.0");
    }

    [MenuItem("Installer/Install Package from YandexMetrica")]
    public static void InstallYandexMetrica()
    {
        InstallPackage("https://github.com/forcepusher/com.agava.yandexmetrica.git#1.2.0");
    }

    [MenuItem("Installer/Install All Packages")]
    public static void InstallAllPackages()
    {
        _currentIndex = 0;
        InstallNextPackage();
    }

    private static void InstallNextPackage()
    {
        if (_currentIndex >= _packageUrls.Length)
        {
            Debug.Log("All packages installed.");
            return;
        }

        string packageUrl = _packageUrls[_currentIndex];
        _currentIndex++;

        Debug.Log("Installing package from URL: " + packageUrl);

        // Ќачинаем установку текущего пакета
        AddRequest request = Client.Add(packageUrl);

        EditorApplication.update = () =>
        {
            if (request.IsCompleted)
            {
                if (request.Status == StatusCode.Success)
                {
                    Debug.Log("Package installed successfully!");
                    EditorApplication.update = null;

                    // ѕродолжаем установку следующего пакета
                    InstallNextPackage();
                }
                else
                {
                    Debug.LogError("Package installation failed: " + request.Error.message);
                    EditorApplication.update = null;
                }
            }
        };
    }

    private static void InstallPackage(string packageURL)
    {
        AddRequest request = Client.Add(packageURL);
        EditorApplication.update = () =>
        {
            if (request.IsCompleted)
            {
                if (request.Status == StatusCode.Success)
                {
                    Debug.Log("Package installed successfully!");
                }
                else
                {
                    Debug.LogError("Package installation failed: " + request.Error.message);
                }
                EditorApplication.update = null;
            }
        };
    }

    private static void AddSceneInitialized()
    {
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        string scenePath = "Assets/LoadingSystem/InitializeScene.unity";
        bool sceneAlreadyAdded = false;

        foreach (EditorBuildSettingsScene buildScene in scenes)
        {
            if (buildScene.path == scenePath)
            {
                sceneAlreadyAdded = true;
                break;
            }
        }

        if (!sceneAlreadyAdded)
        {
            EditorBuildSettingsScene[] newScenes = new EditorBuildSettingsScene[scenes.Length + 1];
            scenes.CopyTo(newScenes, 0);
            newScenes[newScenes.Length - 1] = new EditorBuildSettingsScene(scenePath, true);

            EditorBuildSettings.scenes = newScenes;

            BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "BuildTargetPath", BuildTarget.StandaloneWindows, BuildOptions.None);

            Debug.Log("Scene added to Build Settings.");
        }
        else
        {
            Debug.Log("Scene is already in Build Settings.");
        }
    }
}
#endif