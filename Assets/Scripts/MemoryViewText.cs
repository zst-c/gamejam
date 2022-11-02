using UnityEngine;

public class MemoryViewText : MonoBehaviour{
	public GameMemory memory;

	private void OnGUI(){
		var width = 16 * 28 + 14;
		var height = 16 * 24 + 12;
		int baseX = Screen.width - width, baseY = Screen.height - height;
		// rows of 32
		GUI.color = Color.black;
		GUI.Box(new Rect(baseX - 14, baseY - 8, width, height), "");
		for(int x = 0; x < 16; x++){
			for(int y = 0; y < 16; y++){
				var idx = x + y * 16;
				GUI.color = memory.updated[idx] ? Color.yellow : Color.white;
				GUI.Label(new Rect(x * 28 + baseX, y * 24 + baseY, 100, 100), memory.memory[idx].ToString());
			}
		}
	}
}