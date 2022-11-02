using UnityEngine;

    public class MainMenuScene : MonoBehaviour
    {
        public void StartGame()
        {
            Navigator.Instance.LoadScene(Scenes.Level1Scene);
        }

        public void OpenSettings()
        {
            Navigator.Instance.ToggleSettings();
        }
    }