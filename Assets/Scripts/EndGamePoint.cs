using UnityEngine;

public class EndGamePoint : MonoBehaviour{

	private void Update(){
		var player = FindObjectOfType<PlayerController>();
		if((player.transform.position - gameObject.transform.position).magnitude < 0.5){
			Navigator.Instance.LoadScene(Scenes.EndScene);
		}
	}
}