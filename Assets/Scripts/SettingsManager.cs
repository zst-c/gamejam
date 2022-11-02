using System.Collections.Generic;
using UnityEngine.UI;

public class SettingsManager
{
    private static SettingsManager _instance;

    public static SettingsManager Instance
    {
        get => _instance ??= new SettingsManager();
        set => _instance = value;
    }

    public int Volume = 100;
    public int Brightness = 100;
    public bool Debug = false;
}