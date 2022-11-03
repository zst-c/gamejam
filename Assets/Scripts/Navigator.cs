using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public static class Scenes
{
    public const string MainMenuScene = "Main Menu";
    public const string NewGameScene = "EnterNameScene";
    public const string Level1Scene = "Level 1";
    public const string Level2Scene = "Level 2";
    public const string NameScene = "EnterNameScene";
    public const string Cutscene = "Cutscene";
}

public class Navigator
{
    private const string PersistentSceneName = "Persistent Scene";
    private const string SettingsSceneName = "Settings";

    private GameObject selectedInput;

    private SettingsManager settingsManager = SettingsManager.Instance;

    private static Navigator _instance;

    public static Navigator Instance
    {
        get => _instance ??= new Navigator();
        private set => _instance = value;
    }

    private readonly Stack<string> _sceneStack = new();

    public void LoadScene(string sceneName)
    {
        if (_sceneStack.TryPop(out string oldSceneName))
            SceneManager.UnloadSceneAsync(oldSceneName);
        _sceneStack.Push(sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void ToggleSettings()
    {
        if (_sceneStack.Peek() == SettingsSceneName)
            CloseSettings();
        else
            OpenSettings();
    }

    private void OpenSettings()
    {
        selectedInput = EventSystem.current.currentSelectedGameObject;
        Time.timeScale = 0;
        _sceneStack.Push(SettingsSceneName);
        SceneManager.LoadScene(SettingsSceneName, LoadSceneMode.Additive);
    }

    private void CloseSettings()
    {
        _sceneStack.Pop();
        SceneManager.UnloadSceneAsync(SettingsSceneName);
        EventSystem.current.SetSelectedGameObject(selectedInput);
        Time.timeScale = 1;
    }

    public void ExitToMainMenu()
    {
        while (_sceneStack.TryPop(out var sceneName))
            SceneManager.UnloadSceneAsync(sceneName);

        LoadScene(Scenes.MainMenuScene);
    }
}