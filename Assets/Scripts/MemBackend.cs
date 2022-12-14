using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemBackend
{
    private readonly List<MemCell> _cells;
    private readonly GridLayoutGroup _grid;

    public MemBackend(IEnumerable<string> labels, GridLayoutGroup grid, TMP_FontAsset font)
    {
        _cells = labels.Select(label => new MemCell(label, 0)).ToList();
        _grid = grid;
        foreach (var cell in _cells)
        {
            var cellObj = new GameObject("Cell");
            var cellView = cellObj.AddComponent<VerticalLayoutGroup>();
            cellView.spacing = 10f;
            cellView.transform.SetParent(grid.transform);
            var byteObj = new GameObject("Byte");
            var byteView = byteObj.AddComponent<HorizontalLayoutGroup>();
            byteView.spacing = 10f;
            byteView.transform.SetParent(cellView.transform);
            byteView.GetComponent<RectTransform>().transform.localScale = new Vector3(1f, 1f, 0f);
            for (int i = 0; i < MemCell.BitsLen; i++)
            {
                var bitView = new GameObject("Bit").AddComponent<TextMeshProUGUI>();
                bitView.transform.SetParent(byteView.transform);
                bitView.font = font;
                bitView.alignment = TextAlignmentOptions.Center;
                bitView.GetComponent<RectTransform>().transform.localScale = new Vector3(1f, 1f, 0f);
            }
            UpdateCellView(cellView.gameObject, cell);
            cellView.GetComponent<RectTransform>().transform.localScale = new Vector3(0.75f, 0.75f, 0f);

            var label = new GameObject("Label").AddComponent<TextMeshProUGUI>();
            label.transform.SetParent(cellView.transform);
            label.font = font;
            label.fontSize = 15f;
            label.alignment = TextAlignmentOptions.Center;
            label.text = cell.Label;
            label.GetComponent<RectTransform>().transform.localScale = new Vector3(1.25f, 1.25f, 0f);
        }
    }

    public void UpdateCell(int i, byte newBits)
    {
        _cells[i].Update(newBits);
        UpdateCellView(_grid.transform.GetChild(i).gameObject, _cells[i]);
    }

    private void UpdateCellView(GameObject cellObj, MemCell cell)
    {
        for (int i = 0; i < MemCell.BitsLen; i++)
        {
            var byteViewTransform = cellObj.transform.GetChild(0).transform;
            var component = byteViewTransform.GetChild(i).transform.GetComponent<TextMeshProUGUI>();
            int bit = 1 << i;
            int bitComp = cell.Bits & bit;
            component.text = bitComp == bit ? "1" : "0";
        }
    }
}

internal class MemCell
{
    public const int BitsLen = 4;

    public readonly string Label;
    public byte Bits { get; private set; }

    public MemCell(string label, byte bits)
    {
        Label = label;
        Bits = bits;
    }

    public void Update(byte newBits)
    {
        Bits = newBits;
    }
}