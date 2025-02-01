using UnityEngine;

public class CounterSwitcher : MonoBehaviour
{
    [SerializeField] private AnimationClip _buttonClick;
    [SerializeField] private Animator _buttonAnimator;
    [SerializeField] private Counter _counter;
    [SerializeField] private GameObject _lockImage;

    private bool _isLockVisible;

    private void Start()
    {
        _isLockVisible = false;
        _lockImage.SetActive(_isLockVisible);
    }
    public void ClickCounterButton()
    {
        _buttonAnimator.Play(_buttonClick.name);
        _counter.SwitchCoroutineState();
        _isLockVisible = !_isLockVisible;
        _lockImage.SetActive(_isLockVisible);
    }
}
