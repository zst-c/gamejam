using System;
using System.Linq;
using UnityEngine;

public class Level1Controller : MemoryScene
{
    private const byte BerryByte = 8;
    private const byte BossByte1 = 7;
    private const byte BossByte2 = 15;

    private int _overflowBerries = 0;
    private readonly bool[] _hotBarBerries = { false, false, false, false };
    private bool _isBossDead = false;

    protected override string[] Labels
    {
        get
        {
            return _isBossDead
                ? new[] { "ber0", "ber1", "ber2", "ber3", "tile0", "tile1" }
                : new[] { "ber0", "ber1", "ber2", "ber3", "boss0", "boss1" };
        }
    }

    public void PickUpBerry()
    {
        int index = Array.IndexOf(_hotBarBerries, false);
        ToggleBerry(index, false);
    }

    public void DropBerry(int index)
    {
        ToggleBerry(index, true);
    }

    private void ToggleBerry(int index, bool reset)
    {
        if (index == -1)
        {
            _overflowBerries += reset ? -1 : 1;
            UpdateMemory(_overflowBerries + 3, reset);
        }
        else
        {
            _hotBarBerries[index] = !reset;
            UpdateMemory(index, reset);
        }
    }

    private void UpdateMemory(int index, bool reset = false)
    {
        byte newValue;
        if (reset)
            newValue = 0;
        else if (index == 4)
            newValue = BossByte1;
        else if (index == 5)
            newValue = BossByte2;
        else
            newValue = BerryByte;

        Memory.UpdateCell(index, newValue);
    }
}