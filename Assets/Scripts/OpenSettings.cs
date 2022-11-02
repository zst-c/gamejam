using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettings : MonoBehaviour
{
    public bool settingsAreOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
            settingsAreOpen = true;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}