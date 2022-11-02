using UnityEngine;

public class MemBackedTextField : MonoBehaviour{
	
	private string text = "";

	public GameMemory memory;
	public int ptr;

	public Font font;
	
	private void OnGUI(){
		const int width = 700, height = 40;
		GUIStyle style = new(GUI.skin.textField){
			font = font
		};
		text = GUI.TextField(new Rect((Screen.width - width) / 2f, (Screen.height - height) / 2f, width, height), text, 48, style);
		byte[] newData = System.Text.Encoding.ASCII.GetBytes(text);
		memory.ChangeMemory(() => {
			memory.memory[0] = (byte)text.Length;
			for(int i = 0; i < newData.Length; i++){
				memory.memory[ptr + i + 1] = newData[i];
			}
		});
	}
}