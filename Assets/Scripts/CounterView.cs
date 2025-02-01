using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        _counter.ValueChanged += DisplayNewValue; 
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= DisplayNewValue; 
    }

    private void DisplayNewValue() 
    {
        int currentValue = _counter.CurrentValue;

        _counterText.text = currentValue.ToString();
    }
}
