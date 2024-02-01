using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _capyFinishPrefab;
    [SerializeField] private List<GameObject> _spawnPointsList;
    [SerializeField] private List<GameObject> _finishedCapys;

    public static event Action PlayerFinished;
    public static event Action CapyFinishedForUI;
    public static event Action CapyFinishedForEnemy;
    public static event Action ChildCapybarasFinishReached;
    public static event Action<int> AmountOfChildCapybarasSaved;

    private int _savedChildCapybarasAmount = 0;
    private int _currentChildCapybaraIndex = 0;

    private void OnEnable()
    {
        ObservedCapy.CapyOnFinish += OnCapyOnFinish;
        LevelManager.NotifyFinishAboutLevelFinished += GetAmountOfSavedChildCapybaras;
    }

    private void OnDisable()
    {
        ObservedCapy.CapyOnFinish -= OnCapyOnFinish;
        LevelManager.NotifyFinishAboutLevelFinished -= GetAmountOfSavedChildCapybaras;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (IsChildCapybarasRemaining() == true)
            {
                Debug.Log("Дошли до финиша с капибарами!");
                PlayerFinished?.Invoke();
                ChildCapybarasFinishReached?.Invoke();
                NotifyUiAboutFinish();
                NotifyEnemyAboutFinish();
            }

            if (IsStartPoolChildCapybarasRemaining() == true)
            {
                ChildCapybarasFinishReached?.Invoke();
                Debug.Log("Дошли до финиша без капибар!");
            }
        }
    }

    private bool IsChildCapybarasRemaining()
    {
        ChildCapybara[] capybaras = FindObjectsOfType<ChildCapybara>();

        if (capybaras.Length == 0)
        {
            Debug.Log("No LittleCapybaras left on the finish.");
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
            Debug.Log("No StartPoolChildCapybaras left on the level.");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void NotifyUiAboutFinish()
    {
        foreach (GameObject capy in _finishedCapys)
        {
            CapyFinishedForUI?.Invoke();
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
            _currentChildCapybaraIndex++;
            Debug.Log("Создали финишную капибару. Index: " + _currentChildCapybaraIndex);
            _savedChildCapybarasAmount++;
        }
    }
}
