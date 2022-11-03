using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, ISelectHandler
{
    [SerializeField] GameObject sfxButtonHighlight;
    [SerializeField] GameObject sfxButtonClick;

    public void OnSelect(BaseEventData eventData)
    {
        PlayHoverSound();
    }

    public void PlayHoverSound()
    {
        Instantiate(sfxButtonHighlight, transform.position, Quaternion.identity);
    }

    public void PlayClickSound()
    {
        Instantiate(sfxButtonClick, transform.position, Quaternion.identity);
    }
}
