using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class LabeledIntUI : MonoBehaviour
{
    public TMP_Text _textComponent;
    public string _label = "Gems";
    public int _value = 0;
    public string _label2 = "Coins";
    public int _value2 = 0;

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
    public void SetLabel2(string label)
    {
        _label2 = label;
        UpdateText();
    }

    public void SetValue2(int value)
    {
        _value2 = value;
        UpdateText();
    }

    public void ChangeValue2(int delta)
    {
        _value2 += delta;
        UpdateText();
    }

    private void OnValidate()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _textComponent.text = string.Format("{0}: {1:000} {2}: {3:000}", _label, _value, _label2, _value2);

    }
}