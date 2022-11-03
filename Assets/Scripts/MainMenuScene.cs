using UnityEngine;
using UnityEngine.UI;

public class MainMenuScene : MonoBehaviour
{
    public Button startButton;

    private void Start()
    {
        startButton.Select();
    }

    public void StartGame()
    {
        Navigator.Instance.LoadScene(Scenes.NewGameScene);
    }

    public void OpenSettings()
    {
        Navigator.Instance.ToggleSettings();
    }
}