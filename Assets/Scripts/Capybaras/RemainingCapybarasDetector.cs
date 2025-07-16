using System.Collections;
using Scripts.Services;
using UnityEngine;

namespace Scripts.Capybaras
{
    public class RemainingCapybarasDetector : MonoBehaviour
    {
        [SerializeField] private GameEventBus _eventBus;

        private bool _isAllCapybarasSpawned = false;
        private bool _isAllCapybarasReachedFinish = false;
        private bool _coroutineRunning = true;

        private void Start()
        {
            StartCoroutine(CheckRemainingCapybaras());
        }

        private void OnEnable()
        {
            _eventBus.OnAllCapybarasSpawned += HandleAllCapybarasSpawned;
            _eventBus.OnAllCapybarasReachedFinish += HandleAllCapybarasReachedFinish;
        }

        private void OnDisable()
        {
            _eventBus.OnAllCapybarasSpawned -= HandleAllCapybarasSpawned;
            _eventBus.OnAllCapybarasReachedFinish -= HandleAllCapybarasReachedFinish;
        }

        private IEnumerator CheckRemainingCapybaras()
        {
            while (_coroutineRunning)
            {
                if (_isAllCapybarasSpawned && _isAllCapybarasReachedFinish)
                {
                    yield return new WaitForSeconds(1f);

                    ChildCapybara[] capybaras = FindObjectsOfType<ChildCapybara>();
                
                    if (capybaras.Length == 0)
                    {
                        _eventBus.ChildCapybarasEnded();
                        _coroutineRunning = false;
                    }
                }

                yield return null;
            }
        }

        private void HandleAllCapybarasSpawned()
        {
            _isAllCapybarasSpawned = true;
        }

        private void HandleAllCapybarasReachedFinish()
        {
            _isAllCapybarasReachedFinish = true;
        }
    }
}