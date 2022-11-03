using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewGameScene : MonoBehaviour
{
    public GridLayoutGroup memoryGrid;
    public TMP_FontAsset font;

    private MemBackend _memory;

    private void Start()
    {
        string[] labels = { "usnm [0]", "usnm [1]", "btn_Cc", "btn_Ok" };
        _memory = new MemBackend(labels, memoryGrid, font);
    }


}