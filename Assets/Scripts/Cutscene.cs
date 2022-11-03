using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] float timeToNextScene = 50f;
    
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    private void Update()
    {
#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Navigator.Instance.LoadScene(Scenes.MainMenuScene);
        }
#endif
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(timeToNextScene);
        Navigator.Instance.LoadScene(Scenes.MainMenuScene);
    }
}
