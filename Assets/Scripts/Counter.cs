using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action ValueChanged;

    [SerializeField] private float _delay = 1.0f;
    [SerializeField][Range(1,1000)] private int _maxValue = 1000;
    
    private int _currentValue;
    
    private bool _isOn;

    public int CurrentValue => _currentValue;

    private void Start()
    {
        _currentValue = 0;
        _isOn = true;
        StartCoroutine(IncreaseValueWithDelay(_delay,_maxValue));
    }

    public void SwitchCounterState() 
    {
        _isOn = !_isOn;
    }

    private IEnumerator IncreaseValueWithDelay(float delay,float maxValue)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (_currentValue < maxValue ) 
        {
            if (_isOn)
            {
                _currentValue++;
                ValueChanged?.Invoke();
            }

            yield return wait;
        }
    }
}
