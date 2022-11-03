using UnityEngine;

public class Level2Point : MonoBehaviour{

	private void Update(){
		var player = FindObjectOfType<PlayerController>();
		if((player.transform.position - gameObject.transform.position).magnitude < 0.5){
			Navigator.Instance.LoadScene(Scenes.Level2Scene);
		}
	}
}