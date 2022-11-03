using UnityEngine;

public class Key : MonoBehaviour{

	public string Colour = "";
	
	public void CheckUnlock(){ // scuffed "collision"
		var pos = gameObject.transform.position;
		foreach(var unlockable in FindObjectsOfType<Unlockable>()){
			if(unlockable.Colour == Colour && (unlockable.gameObject.transform.position - pos).magnitude < 0.5){
				Destroy(unlockable.gameObject);
				Destroy(gameObject);
				break;
			}
		}
	}
}