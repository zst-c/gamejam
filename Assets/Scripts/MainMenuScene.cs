using UnityEngine;

    public class MainMenuScene : MonoBehaviour
    {
        public void StartGame()
        {
            Navigator.Instance.LoadScene(Scenes.TutorialScene);
        }

        public void OpenSettings()
        {
            Navigator.Instance.ToggleSettings();
        }
    }