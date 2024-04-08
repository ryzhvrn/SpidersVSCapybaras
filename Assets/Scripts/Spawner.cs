using System;
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
    [SerializeField] private float _radius = 5f;

    private int _spawnedCapybaraIndex = 0;
    private int _maximumChildCapybarasForSpawnAmount;
    private int _spawnedCapybarasAmount = 0;
    private Vector3 _center;

    public static event Action<Capy> ChildCapybaraSpawned;
    public static event Action<int> ChildCapybarasSpawned;

    private void Start()
    {
        _maximumChildCapybarasForSpawnAmount = _childCapybarasForSpawnList.Count;
        _center = transform.position;
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
    }

    private void OnPlayerDetected()
    {
        if (_spawnedCapybarasAmount < _maximumChildCapybarasForSpawnAmount)
        {
            Vector3 position = RandomCircle(_center, _radius);

            Capy spawnedCapy = Instantiate(_capybaraChildPrefab, position, transform.rotation);
            ChildCapybaraSpawned?.Invoke(spawnedCapy);
            _spawnedCapybarasAmount++;
            Destroy(_childCapybarasForSpawnList[_spawnedCapybaraIndex]);
            _spawnedCapybaraIndex++;
        }

        if (_spawnedCapybarasAmount == _maximumChildCapybarasForSpawnAmount)
        {
            NotifyLevelManagerAboutSpawnedCapybarasAmount();
            _waypointScript.enabled= false;
            _waypointImage.enabled= false;
            _waypointText.enabled = false;
            enabled = false;
        }
    }

    private Vector3 RandomCircle(Vector3 center, float radius)
    {
        float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2);

        float x = center.x + radius * Mathf.Cos(angle);
        float z = center.z + radius * Mathf.Sin(angle);

        return new Vector3(x, center.y, z);
    }
}
