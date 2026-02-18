using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class LabeledIntUI : MonoBehaviour
{
    public TMP_Text _textComponent;
    public string _label = "value";
    public int _value = 0;

    private void Start()
    {
        _textComponent = GetComponent<TMP_Text>();
        UpdateText();
    }

    public void SetLabel(string label)
    {
        _label = label;
        UpdateText();
    }

    public void SetValue(int value)
    {
        _value = value;
        UpdateText();
    }

    public void ChangeValue(int delta)
    {
        _value += delta;
        UpdateText();
    }

    private void OnValidate()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _textComponent.text = string.Format("{0}: {1:000}", _label, _value);

    }
}