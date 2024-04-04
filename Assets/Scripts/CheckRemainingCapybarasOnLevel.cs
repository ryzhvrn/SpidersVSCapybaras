using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRemainingCapybarasOnLevel : MonoBehaviour
{
    private bool _isAllChildCapybarasSpawned = false;
    private bool _isChildCapybarasFinishReached = false;
    private bool _isCoroutineWorking = true;

    public static event Action ChildCapybarasEnded;

    private void Start()
    {
        StartCoroutine(CheckLevelForRemainingChildCapybaras());
    }

    private void OnEnable()
    {
        Finish.ChildCapybarasFinishReached += OnChildCapybarasFinishReached;
        LevelManager.AllChildCapybarasSpawned += OnAllChildCapybarasSpawned;
    }

    private void OnDisable()
    {
        Finish.ChildCapybarasFinishReached -= OnChildCapybarasFinishReached;
        LevelManager.AllChildCapybarasSpawned -= OnAllChildCapybarasSpawned;
    }

    private IEnumerator CheckLevelForRemainingChildCapybaras()
    {
        do
        {
            if (_isAllChildCapybarasSpawned == true && _isChildCapybarasFinishReached == true)
            {
                yield return new WaitForSeconds(1f);

                ChildCapybara[] capybaras = FindObjectsOfType<ChildCapybara>();

                if (capybaras.Length == 0)
                {
                    ChildCapybarasEnded?.Invoke();
                    _isCoroutineWorking = false;
                }
            }
            yield return null;
        }
        while (_isCoroutineWorking);
    }

    private void OnChildCapybarasFinishReached()
    {
        _isAllChildCapybarasSpawned = true;
    }

    private void OnAllChildCapybarasSpawned()
    {
        _isChildCapybarasFinishReached = true;
    }
}
