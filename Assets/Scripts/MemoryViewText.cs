using UnityEngine;

public class MemoryViewText : MonoBehaviour{
	public GameMemory memory;

	private void OnGUI(){
		var width = 8 * 28 + 14;
		var height = 32 * 24 + 12;
		int baseX = Screen.width - width, baseY = 24;
		// rows of 32
		GUI.color = Color.black;
		GUI.Box(new Rect(baseX - 14, baseY - 8, width, height), "");
		for(int x = 0; x < 8; x++){
			for(int y = 0; y < 32; y++){
				var idx = x + y * 8;
				GUI.color = memory.updated[idx] ? Color.yellow : Color.white;
				GUI.Label(new Rect(x * 28 + baseX, y * 24 + baseY, 100, 100), memory.memory[idx].ToString());
			}
		}
	}
}