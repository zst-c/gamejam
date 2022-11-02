using System.Linq;
using UnityEngine;

public class MemBackedText : MonoBehaviour{

	public GameMemory memory;
	public int ptr, length;

	private void OnGUI(){
		string text = System.Text.Encoding.ASCII.GetString(memory.memory.Skip(ptr).Take(length).ToArray());
		GUI.Label(new Rect(transform.position, new Vector2(100, 100)), text);
	}
}