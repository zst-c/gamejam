using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemBackedText : MonoBehaviour{

	public GameMemory memory;
	public int ptr, length;

	public int x, y;
	public string initialText;

	public Font font;

	private void Awake(){
		byte[] initialBytes = System.Text.Encoding.ASCII.GetBytes(initialText);
		for(int i = 0; i < initialBytes.Length; i++){
			memory.memory[ptr + i] = initialBytes[i];
		}
	}

	private void OnGUI(){
		if (SceneManager.GetSceneAt(SceneManager.sceneCount - 1) != gameObject.scene)
		{
			return;
		}

		string text = System.Text.Encoding.ASCII.GetString(memory.memory.Skip(ptr).Take(length).ToArray());
		GUIStyle style = new(GUI.skin.button){
			font = font,
			alignment = TextAnchor.MiddleCenter
		};
		GUI.Label(new Rect((Screen.width / 2) + x, (Screen.height / 2) + y, 100, 100), text, style);
	}
}