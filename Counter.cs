using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private float _delay = 0.5f;

    private int _value;
    private Coroutine _coroutine;

    public int Value => _value;

    public event UnityAction ValueChanged;

    private void Start()
    {
        _value = 0;
        ValueChanged?.Invoke();
    }

    private void OnEnable()
    {
        _userInput.Clicked += ChangeState;
    }

    private void OnDisable()
    {
        _userInput.Clicked -= ChangeState;
    }

    private void ChangeState()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(IncreaseCounter());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator IncreaseCounter()
    {
        bool isIncrease = true;
        var wait = new WaitForSeconds(_delay);

        while (isIncrease)
        {
            _value++;
            ValueChanged?.Invoke();

            yield return wait;
        }
    }
}