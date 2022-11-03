using UnityEngine;

public class Hotbar : MonoBehaviour
{
    void Awake()
    {
        foreach (var button in GetComponentsInChildren<HotbarButton>())
        {
            // button.OnButtonClicked += ButtonOnOnButtonClicked;
        }
    }

    void ButtonOnOnButtonClicked(int buttonNumber)
    {
        Debug.Log("uhh");
    }
}
