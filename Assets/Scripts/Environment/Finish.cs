using System;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameEventBus _eventBus;
    [SerializeField] private GameObject _capyFinishPrefab;
    [SerializeField] private List<GameObject> _spawnPointsList;
    [SerializeField] private List<GameObject> _finishedCapys;
    
    private int _savedChildCapybarasAmount = 0;
    private int _currentChildCapybaraIndex = 0;

    private void OnEnable()
    {
        _eventBus.OnFinished += OnCapyOnFinish;
        _eventBus.OnNotifyFinishAboutLevelFinished += ReportSavedCapybarasAmount;
    }

    private void OnDisable()
    {
        _eventBus.OnFinished -= OnCapyOnFinish;
        _eventBus.OnNotifyFinishAboutLevelFinished -= ReportSavedCapybarasAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (IsChildCapybarasRemaining())
            {
                _eventBus.PlayerFinished();
                _eventBus.AllCapybarasReachedFinish();
                _eventBus.CapyFinishedForEnemy();
            }

            if (IsStartPoolChildCapybarasRemaining())
            {
                _eventBus.AllCapybarasReachedFinish();
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
    
    private void ReportSavedCapybarasAmount()
    {
        _eventBus.AmountOfCapybarasSaved(_savedChildCapybarasAmount);
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

    private bool IsAnyChildCapybaraRemaining()
    {
        return FindObjectsOfType<ChildCapybara>().Length > 0;
    }

    private bool IsStartPoolCapybarasFinished()
    {
        return FindObjectsOfType<StartPoolChildCapybara>().Length == 0;
    }

    private void OnCapyOnFinish()
    {
        if (_currentChildCapybaraIndex < _spawnPointsList.Count)
        {
            Vector3 spawnPoint = _spawnPointsList[_currentChildCapybaraIndex].transform.position;
            GameObject finishCapy = Instantiate(_capyFinishPrefab, spawnPoint, transform.rotation);
            finishCapy.transform.rotation = Quaternion.Euler(0, 180, 0);
            _finishedCapys.Add(finishCapy);
            _eventBus.CapyFinishedForUI();
            _currentChildCapybaraIndex++;
            _savedChildCapybarasAmount++;
        }
    }
}
