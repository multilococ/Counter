using UnityEngine;
using UnityEngine.UI;

public class CounterSwitcher : MonoBehaviour
{
    [SerializeField] private AnimationClip _buttonClick;
    [SerializeField] private Animator _buttonAnimator;
    [SerializeField] private Counter _counter;
    [SerializeField] private Button _button;
    [SerializeField] private Image _lockImage;

    private bool _isLockVisible;

    private void Start()
    {
        _isLockVisible = false;
        _lockImage.enabled = _isLockVisible;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickCounterButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickCounterButton);
    }

    public void ClickCounterButton()
    {
        _buttonAnimator.Play(_buttonClick.name);
        _counter.SwitchCoroutineState();
        _isLockVisible = !_isLockVisible;
        _lockImage.enabled = _isLockVisible;
    }
}