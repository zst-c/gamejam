using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestroySound : MonoBehaviour
{
    void Start()
    {
        float t = GetComponent<AudioSource>().clip.length;
        Destroy(gameObject, t);
    }
}