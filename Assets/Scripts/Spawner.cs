using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Capy _capybaraChildPrefab;
    [SerializeField] private Waypoint _waypointScript;
    [SerializeField] private Image _waypointImage;
    [SerializeField] private Text _waypointText;
    [SerializeField] private List<GameObject> _childCapybarasForSpawnList = new List<GameObject>();

    public static event Action<Capy> ChildCapybaraSpawned;
    public static event Action<int> ChildCapybarasSpawned;

    private int _spawnedCapybaraIndex = 0;
    private int _maximumChildCapybarasForSpawnAmount;
    private int _spawnedCapybarasAmount = 0;

    private void Start()
    {
        _maximumChildCapybarasForSpawnAmount = _childCapybarasForSpawnList.Count;
        Debug.Log("_maximumCapybarasForSpawnAmount " + _maximumChildCapybarasForSpawnAmount);
    }

    private void OnEnable()
    {
        PlayerDetector.PlayerDetected += OnPlayerDetected;
    }

    private void OnDisable()
    {
        PlayerDetector.PlayerDetected -= OnPlayerDetected;
    }

    private void NotifyLevelManagerAboutSpawnedCapybarasAmount()
    {
        ChildCapybarasSpawned?.Invoke(_maximumChildCapybarasForSpawnAmount);
        Debug.Log("Было заспавнено: " + _maximumChildCapybarasForSpawnAmount + " капибар!");
    }

    private void OnPlayerDetected()
    {
        if (_spawnedCapybarasAmount < _maximumChildCapybarasForSpawnAmount)
        {
            Capy spawnedCapy = Instantiate(_capybaraChildPrefab, transform.position, transform.rotation);
            ChildCapybaraSpawned?.Invoke(spawnedCapy);
            _spawnedCapybarasAmount++;
            Destroy(_childCapybarasForSpawnList[_spawnedCapybaraIndex]);
            _spawnedCapybaraIndex++;
        }

        if (_spawnedCapybarasAmount == _maximumChildCapybarasForSpawnAmount)
        {
            Debug.Log("All capys were summon already!");
            NotifyLevelManagerAboutSpawnedCapybarasAmount();
            _waypointScript.enabled= false;
            _waypointImage.enabled= false;
            _waypointText.enabled = false;
            enabled = false;
        }
    }
}
