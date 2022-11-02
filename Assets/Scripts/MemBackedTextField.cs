using UnityEngine;

public class MemBackedTextField : MonoBehaviour{
	
	private string text = "";

	public GameMemory memory;
	public int ptr;
	
	private void OnGUI(){
		text = GUI.TextField(new Rect(20, 20, 200, 20), text, 32);
		byte[] newData = System.Text.Encoding.ASCII.GetBytes(text);
		for(int i = 0; i < newData.Length; i++){
			memory.memory[ptr + i] = newData[i];
		}
	}
}