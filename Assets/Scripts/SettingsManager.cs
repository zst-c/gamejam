using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private static SettingsManager _instance;

    public static SettingsManager Instance
    {
        get => _instance ??= new SettingsManager();
        set => _instance = value;
    }

    public void ExitToMenu() { SceneManager.LoadScene("Main Menu", LoadSceneMode.Single); }

    public void Return() { SceneManager.UnloadSceneAsync("Settings"); }

    public int Volume = 100;
    public int Brightness = 100;
    public bool Debug = false;
}