using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _capyFinishPrefab;
    [SerializeField] private List<GameObject> _spawnPointsList;
    [SerializeField] private List<GameObject> _finishedCapys;
    private int _savedChildCapybarasAmount = 0;
    private int _currentChildCapybaraIndex = 0;

    public static event Action PlayerFinished;
    public static event Action CapyFinishedForUI;
    public static event Action CapyFinishedForEnemy;
    public static event Action ChildCapybarasFinishReached;
    public static event Action<int> AmountOfChildCapybarasSaved;

    private void OnEnable()
    {
        ObservableSpawnedLittleCapy.Finished += OnCapyOnFinish;
        LevelManager.NotifyFinishAboutLevelFinished += GetAmountOfSavedChildCapybaras;
    }

    private void OnDisable()
    {
        ObservableSpawnedLittleCapy.Finished -= OnCapyOnFinish;
        LevelManager.NotifyFinishAboutLevelFinished -= GetAmountOfSavedChildCapybaras;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (IsChildCapybarasRemaining() == true)
            {
                PlayerFinished?.Invoke();
                ChildCapybarasFinishReached?.Invoke();
                NotifyEnemyAboutFinish();
            }

            if (IsStartPoolChildCapybarasRemaining() == true)
            {
                ChildCapybarasFinishReached?.Invoke();
            }
        }
    }

    private bool IsChildCapybarasRemaining()
    {
        ChildCapybara[] capybaras = FindObjectsOfType<ChildCapybara>();

        if (capybaras.Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool IsStartPoolChildCapybarasRemaining()
    {
        StartPoolChildCapybara[] capybaras = FindObjectsOfType<StartPoolChildCapybara>();

        if (capybaras.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void NotifyEnemyAboutFinish()
    {
        CapyFinishedForEnemy?.Invoke();
    }

    private void GetAmountOfSavedChildCapybaras()
    {
        AmountOfChildCapybarasSaved?.Invoke(_savedChildCapybarasAmount);
    }

    private void OnCapyOnFinish()
    {
        if (_currentChildCapybaraIndex < _spawnPointsList.Count)
        {
            Vector3 spawnPoint = _spawnPointsList[_currentChildCapybaraIndex].transform.position;
            GameObject finishCapy = Instantiate(_capyFinishPrefab, spawnPoint, transform.rotation);
            finishCapy.transform.rotation = Quaternion.Euler(0, 180, 0);
            _finishedCapys.Add(finishCapy);
            CapyFinishedForUI?.Invoke();
            _currentChildCapybaraIndex++;
            _savedChildCapybarasAmount++;
        }
    }
}
