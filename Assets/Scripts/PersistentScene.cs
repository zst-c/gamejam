using System;
using UnityEngine;

public class PersistentScene : MonoBehaviour
{
    private void Start()
    {
        Navigator.Instance.LoadScene(Scenes.MainMenuScene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Navigator.Instance.ToggleSettings();
        }
    }
}