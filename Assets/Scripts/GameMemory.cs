using System;
using UnityEngine;

public class GameMemory : MonoBehaviour{

	public byte[] memory = new byte[256];
	public bool[] updated = new bool[256];

	// Batches a number of changes to memory and tracks what cells were changed
	public void ChangeMemory(Action action){
		var oldMemory = new byte[256];
		var oldChanged = new bool[256];
		// keep track of the previous memory and highlighting
		for(int i = 0; i < 256; i++){
			oldMemory[i] = memory[i];
			oldChanged[i] = updated[i];
		}
		// run batch changes
		action();
		// only update `updated` if anything was changed
		bool commit = false;
		for(var i = 0; i < 256; i++){
			var changed = oldMemory[i] != memory[i];
			updated[i] = changed;
			if(changed)
				commit = true;
		}

		// if nothing was changed, keep old highlighting
		if(!commit)
			updated = oldChanged;
	}
}