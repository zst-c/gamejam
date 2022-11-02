using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextTutorialCompleteTrigger : MonoBehaviour{

	public int ptr;
	public GameMemory memory;
	
	private void Update(){
		if(memory.memory[ptr] != 0)
			SceneManager.LoadScene("Level 1");
	}
}