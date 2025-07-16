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
    [SerializeField] private GameEventBus _eventBus;

    private int _spawnedCapybaraIndex = 0;
    private int _maxCapybaraCount;
    private int _spawnedCapybaraCount = 0;
    private Vector3 _center;

    private void Awake()
    {
        _maxCapybaraCount = _childCapybarasForSpawnList.Count;
        _center = transform.position;
    }

    private void OnEnable()
    {
        _eventBus.OnPlayerDetected += HandlePlayerDetected;
    }

    private void OnDisable()
    {
        _eventBus.OnPlayerDetected -= HandlePlayerDetected;
    }

    private void HandlePlayerDetected()
    {
        if (_spawnedCapybaraCount < _maxCapybaraCount)
        {
            Vector3 spawnPosition = RandomCircle(_center, _radius);
            Capy spawnedCapy = Instantiate(_capybaraChildPrefab, spawnPosition, transform.rotation);

            _eventBus.CapySpawned(spawnedCapy);
            _spawnedCapybaraCount++;

            Destroy(_childCapybarasForSpawnList[_spawnedCapybaraIndex]);
            _spawnedCapybaraIndex++;
        }

        if (_spawnedCapybaraCount == _maxCapybaraCount)
        {
            _eventBus.ChildCapybarasSpawned(_maxCapybaraCount);
            _waypointScript.enabled = false;
            _waypointImage.enabled = false;
            _waypointText.enabled = false;
            enabled = false;
        }
    }

    private Vector3 RandomCircle(Vector3 center, float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float x = center.x + radius * Mathf.Cos(angle);
        float z = center.z + radius * Mathf.Sin(angle);
        return new Vector3(x, center.y, z);
    }
}
