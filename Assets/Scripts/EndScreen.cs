using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    bool hasOpenedGithub = false;
    [SerializeField] GameObject before;
    [SerializeField] GameObject after;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!hasOpenedGithub)
            {
                Application.OpenURL("https://github.com/zst-c/gamejam");
                hasOpenedGithub = true;
                ToggleText();
            }
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            }
        }
    }

    void ToggleText()
    {
        before.SetActive(false);
        after.SetActive(true);
    }
}
