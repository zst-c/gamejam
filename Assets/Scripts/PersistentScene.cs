using UnityEngine;
using UnityEngine.InputSystem;

public class PersistentScene : MonoBehaviour
{
    private void Start()
    {
        Navigator.Instance.LoadScene(Scenes.Level2Scene);
        InputSystem.DisableDevice(Mouse.current);
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Navigator.Instance.ToggleSettings();
    }
}