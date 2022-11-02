using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() { SceneManager.LoadScene("Level 1", LoadSceneMode.Single); }

    public void LoadSettings() { SceneManager.LoadScene("Settings", LoadSceneMode.Single); }
}
