using System;
using UnityEngine;

public class GameMemory : MonoBehaviour{

	public byte[] memory = new byte[256];
	public bool[] updated = new bool[256];

	public void ChangeMemory(Action action){
		var oldMemory = new byte[256];
		var oldChanged = new bool[256];
		for(int i = 0; i < 256; i++){
			oldMemory[i] = memory[i];
			oldChanged[i] = updated[i];
		}
		action();
		bool commit = false;
		for(var i = 0; i < 256; i++){
			var changed = oldMemory[i] != memory[i];
			updated[i] = changed;
			if(changed)
				commit = true;
		}

		if(!commit)
			updated = oldChanged;
	}
}