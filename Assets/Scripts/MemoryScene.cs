using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MemoryScene : MonoBehaviour
{
    public GridLayoutGroup memoryGrid;
    public TMP_FontAsset font;

    protected MemBackend Memory;

    protected abstract string[] Labels { get; }

    private void Start()
    {
        Memory = new MemBackend(Labels, memoryGrid, font);
    }
}