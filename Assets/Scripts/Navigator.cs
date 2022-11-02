using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scenes
{
    public const string MainMenuScene = "Main Menu";
    public const string Level1Scene = "Level 1";
    public const string TutorialScene = "T1 Choose Your Name";
}

public class Navigator
{
    private const string PersistentSceneName = "Persistent Scene";
    private const string SettingsSceneName = "Settings";

    private static Navigator _instance;

    public static Navigator Instance
    {
        get => _instance ??= new Navigator();
        private set => _instance = value;
    }

    // public void StartNavigator()
    // {
    //     _sceneStack.Push(PersistentSceneName);
    //     SceneManager.LoadScene(PersistentSceneName, LoadSceneMode.Single);
    // }

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
        _sceneStack.Push(SettingsSceneName);
        SceneManager.LoadScene(SettingsSceneName, LoadSceneMode.Additive);
    }

    private void CloseSettings()
    {
        _sceneStack.Pop();
        SceneManager.UnloadSceneAsync(SettingsSceneName);
    }

    public void ExitToMainMenu()
    {
        while (_sceneStack.TryPop(out var sceneName))
            SceneManager.UnloadSceneAsync(sceneName);

        LoadScene(Scenes.MainMenuScene);
    }
}