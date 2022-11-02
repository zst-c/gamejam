using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeMeter;

    public Slider brightnessSlider;
    public TextMeshProUGUI brightnessMeter;

    public Button resumeButton;

    private void Start()
    {
        resumeButton.Select();

        SettingsManager.Instance.Volume = (int)volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(delegate(float value)
        {
            SettingsManager.Instance.Volume = (int)value;
            UpdateText();
        });

        SettingsManager.Instance.Brightness = (int)brightnessSlider.value;
        brightnessSlider.onValueChanged.AddListener(delegate(float value)
        {
            SettingsManager.Instance.Brightness = (int)value;
            UpdateText();
        });

        UpdateText();
    }

    private void UpdateText()
    {
        var settings = SettingsManager.Instance;
        volumeMeter.text = GetProgress(settings.Volume);
        brightnessMeter.text = GetProgress(settings.Brightness);
    }

    private static string GetProgress(float value)
    {
        return $"{(int)value}/100";
    }

    public void Close()
    {
        Navigator.Instance.ToggleSettings();
    }

    public void ExitToMainMenu()
    {
        Navigator.Instance.ExitToMainMenu();
    }
}