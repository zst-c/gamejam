using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Scene : MemoryScene
{
    protected override string[] Labels =>
        new[] { "bright0", "bright1", "key" };

    private void Update()
    {
        if (SettingsManager.Instance.Brightness > 100)
            Memory.UpdateCell(2, 15);

    }
}
