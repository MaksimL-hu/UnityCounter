using TMPro;
using UnityEngine;

public class TextRenderer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += ShowCounterValue;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ShowCounterValue;
    }

    private void ShowCounterValue()
    {
        _text.text = _counter.Value.ToString();
    }
}