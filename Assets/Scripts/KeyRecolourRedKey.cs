using UnityEditor;
using UnityEngine;

public class KeyRecolourRedKey : MonoBehaviour{
	
	// convert this to red/green key based on brightness
	private void Update(){
		if(SettingsManager.Instance.Brightness > 128){
			var greenKey = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Full Green Key.prefab");
			greenKey.transform.parent = gameObject.transform.parent;
			greenKey.transform.position = gameObject.transform.position;
			Destroy(gameObject);
		}
	}
}