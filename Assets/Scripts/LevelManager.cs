using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameEventBus _eventBus;

    private int _maxChildCapybarasAmount;
    private int _currentSpawnedCapybaras;
    private int _savedCapybaras;
    private bool _hasFiredAllSpawned = false;
    private string _sceneName;
    private int _earnedStars;

    private void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        CalculateMaxCapybarasFromScene();
    }

    private void OnEnable()
    {
        _eventBus.OnChildCapybarasSpawned += OnCapybarasSpawned;
        _eventBus.OnChildCapybarasEnded += OnCapybarasEnded;
        _eventBus.OnAmountOfCapybarasSaved += OnCapybarasSaved;
        _eventBus.OnLevelsSceneActivated += OnLevelsSceneActivated;
    }

    private void OnDisable()
    {
        _eventBus.OnChildCapybarasSpawned -= OnCapybarasSpawned;
        _eventBus.OnChildCapybarasEnded -= OnCapybarasEnded;
        _eventBus.OnAmountOfCapybarasSaved -= OnCapybarasSaved;
        _eventBus.OnLevelsSceneActivated -= OnLevelsSceneActivated;
    }

    private void Update()
    {
        if (!_hasFiredAllSpawned && _currentSpawnedCapybaras == _maxChildCapybarasAmount)
        {
            _eventBus.AllCapybarasSpawned();
            _hasFiredAllSpawned = true;
        }
    }

    private void OnLevelsSceneActivated()
    {
        LevelsMenu.Load();
    }

    private void OnCapybarasSpawned(int amount)
    {
        _currentSpawnedCapybaras += amount;
    }

    private void OnCapybarasSaved(int amount)
    {
        _savedCapybaras = amount;
    }

    private void OnCapybarasEnded()
    {
        _eventBus.NotifyFinishAboutLevelFinished();
        CalculateStars();
        _eventBus.NotifyLevelConfigAboutAmountOfEarnedStars(_earnedStars, _sceneName);
        _eventBus.CurrentLevelFinished();
    }

    private void CalculateMaxCapybarasFromScene()
    {
        var capyPools = FindObjectsOfType<StartPoolChildCapybara>();
        _maxChildCapybarasAmount = capyPools.Length;
    }

    private void CalculateStars()
    {
        float percent = (_maxChildCapybarasAmount > 0)
            ? ((float)_savedCapybaras / _maxChildCapybarasAmount) * 100f
            : 0f;

        if (percent == 100)
            _earnedStars = 3;
        else if (percent >= 66)
            _earnedStars = 2;
        else if (percent >= 33)
            _earnedStars = 1;
        else
            _earnedStars = 0;
    }
}
