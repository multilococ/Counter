using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action ValueChanged;

    [SerializeField] private float _delay = 1.0f;
    [SerializeField][Range(1, 1000)] private int _maxValue = 1000;

    private int _currentValue;

    private Coroutine _increseValue;

    public int CurrentValue => _currentValue;

    private void Start()
    {
        _currentValue = 0;
        SwitchCoroutineState();
    }

    public void SwitchCoroutineState()
    {
        if (_increseValue != null)
        {
            StopCoroutine(_increseValue);
            _increseValue = null;
        }
        else
        {
            _increseValue = StartCoroutine(IncreaseValueWithDelay(_delay, _maxValue));
        }
    }

    private IEnumerator IncreaseValueWithDelay(float delay, float maxValue)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (_currentValue < maxValue)
        {
            _currentValue++;
            ValueChanged?.Invoke();

            yield return wait;
        }
    }
}
