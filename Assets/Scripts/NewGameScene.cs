using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewGameScene : MemoryScene
{
    public TMP_InputField inputField;
    public TextMeshProUGUI buttonOkText;
    public TextMeshProUGUI buttonCancelText;

    protected override string[] Labels
    {
        get
        {
            var labels = new[] { "usnm [0]", "usnm [1]", "btn_Cc", "btn_Ok" };
            return labels;
        }
    }

    protected override void Start()
    {
        base.Start();
        inputField.Select();
        inputField.onValueChanged.AddListener(UpdateUI);
    }

    private void UpdateUI(string text)
    {
        int byteIndex = text.Length / MemCell.BitsLen;

        {
            string subStr = Substring(text, 0);
            Memory.UpdateCell(0, GetByte(subStr));
        }
        if (byteIndex >= 1)
        {
            string subStr = Substring(text, 1);
            Memory.UpdateCell(1, GetByte(subStr));
        }

        if (byteIndex >= 2)
        {
            string subStr = Substring(text, 2);
            Memory.UpdateCell(2, GetByte(subStr));
            buttonCancelText.text = subStr.Length > 0 ? subStr : "Cancel";
        }

        if (byteIndex >= 3)
        {
            string subStr = Substring(text, 3);
            Memory.UpdateCell(3, GetByte(subStr));
            buttonOkText.text = subStr.Length > 0 ? subStr : "Ok";
        }

        if (byteIndex >= 4 && text.Length % MemCell.BitsLen != 0)
            Navigator.Instance.LoadScene(Scenes.Level1Scene);
    }

    private string Substring(string s, int cellIndex)
    {
        int len = Math.Min(s.Length - cellIndex * MemCell.BitsLen, MemCell.BitsLen);
        return s.Substring(cellIndex * MemCell.BitsLen, len);
    }

    private byte GetByte(string text)
    {
        int length = text.Length;
        int result = 0;
        for (int i = 0; i < length; i++)
        {
            result <<= 1;
            result |= 1;
        }

        return (byte)result;
    }
}