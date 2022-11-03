using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeMeter;

    public Slider brightnessSlider;
    public TextMeshProUGUI brightnessMeter;

    public Toggle debug;

    private void Start()
    {
        volumeSlider.GetComponent<Slider>().value = SettingsManager.Instance.Volume;
        volumeSlider.onValueChanged.AddListener(delegate(float value)
        {
            SettingsManager.Instance.Volume = (int)value;
            UpdateText();
        });

        brightnessSlider.GetComponent<Slider>().value = SettingsManager.Instance.Brightness;
        brightnessSlider.onValueChanged.AddListener(delegate(float value)
        {
            SettingsManager.Instance.Brightness = (int)value;
            UpdateText();
        });

        UpdateText();

        debug.GetComponent<Toggle>().isOn = SettingsManager.Instance.Debug;
        debug.onValueChanged.AddListener(delegate(bool isChecked){
            SettingsManager.Instance.Debug = isChecked;
            debug.GetComponent<Toggle>().isOn = SettingsManager.Instance.Debug;
        });

        volumeSlider.Select();
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