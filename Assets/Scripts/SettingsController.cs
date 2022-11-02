using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    private int _brightness;
    public Text brightness;

    public void Update()
    {
        brightness.text = $"{_brightness}/100";
    }

    public void SetBrightness() {}
}