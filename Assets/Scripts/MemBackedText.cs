using System.Linq;
using UnityEngine;

public class MemBackedText : MonoBehaviour{

	public GameMemory memory;
	public int ptr, length;

	public int x, y;
	public string initialText;

	private void Awake(){
		byte[] initialBytes = System.Text.Encoding.ASCII.GetBytes(initialText);
		for(int i = 0; i < initialBytes.Length; i++){
			memory.memory[ptr + i] = initialBytes[i];
		}
	}

	private void OnGUI(){
		string text = System.Text.Encoding.ASCII.GetString(memory.memory.Skip(ptr).Take(length).ToArray());
		GUI.Label(new Rect((Screen.width / 2) + x, (Screen.height / 2) + y, 100, 100), text);
	}
}