using UnityEditor;
using UnityEngine;

public class Key : MonoBehaviour{

	public string Colour = "";
	
	public void CheckUnlock(){ // scuffed "collision"
		var pos = gameObject.transform.position;
		foreach(var unlockable in FindObjectsOfType<Unlockable>()){
			var uObj = unlockable.gameObject;
			if(unlockable.Colour == Colour && (uObj.transform.position - pos).magnitude < 0.5){
				var finishLine = PrefabUtility.LoadPrefabContents("Assets/Prefabs/finish line.prefab");
				finishLine = Instantiate(finishLine);
				finishLine.transform.parent = gameObject.transform.parent;
				finishLine.transform.position = gameObject.transform.position;
				Destroy(uObj);
				Destroy(gameObject);
				break;
			}
		}
	}
}