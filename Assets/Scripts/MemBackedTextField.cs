using UnityEngine;
using UnityEngine.SceneManagement;

public class MemBackedTextField : MonoBehaviour{
	
	private string text = "";

	public GameMemory memory;
	public int ptr;

	public Font font;
	public int x;
	
	private void OnGUI(){
		if (SceneManager.GetSceneAt(SceneManager.sceneCount - 1) != gameObject.scene)
		{
			return;
		}

		const int width = 700, height = 40;
		GUIStyle style = new(GUI.skin.textField){
			font = font,
			alignment = TextAnchor.MiddleCenter
		};
		text = GUI.TextField(new Rect((Screen.width - width) / 2f + x, (Screen.height - height) / 2f, width, height), text, 48, style);
		byte[] newData = System.Text.Encoding.ASCII.GetBytes(text);
		memory.ChangeMemory(() => {
			memory.memory[0] = (byte)text.Length;
			for(int i = 0; i < newData.Length; i++){
				memory.memory[ptr + i + 1] = newData[i];
			}
		});
	}
}