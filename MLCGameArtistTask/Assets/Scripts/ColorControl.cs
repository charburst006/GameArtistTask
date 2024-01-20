using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ColorControl : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField InputRValue;

    [SerializeField]
    public TMP_InputField InputGValue;

    [SerializeField]
    public TMP_InputField InputBValue;

    [SerializeField]
    public UnityEvent<Color> OnColorChanged;

    private void Start()
    {
        InputRValue.text = "255";
        InputGValue.text = "255";
        InputBValue.text = "255";

        InvokeSetColor();

        InputRValue.onValueChanged.AddListener(OnRGBValueChanged);
        InputGValue.onValueChanged.AddListener(OnRGBValueChanged);
        InputBValue.onValueChanged.AddListener(OnRGBValueChanged);
    }

    Color GetColor()
    {
        return new Color(
            Mathf.Clamp(int.Parse(InputRValue.text), 0, 255) / 255.0f,
            Mathf.Clamp(int.Parse(InputGValue.text), 0, 255) / 255.0f,
            Mathf.Clamp(int.Parse(InputBValue.text), 0, 255) / 255.0f
            );
    }

    void InvokeSetColor()
    {
        OnColorChanged?.Invoke(GetColor());
    }

    void OnRGBValueChanged(string text)
    {
        if (text == string.Empty)
            return;

        InvokeSetColor();
    }
}
