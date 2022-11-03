using UnityEditor;
using UnityEngine;

public class KeyRecolourGreenKey : MonoBehaviour{
	
	// convert this to red/green key based on brightness
	private void Update(){
		if(SettingsManager.Instance.Brightness <= 128){
			var redKey = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Full Red Key.prefab");
			redKey.transform.parent = gameObject.transform.parent;
			redKey.transform.position = gameObject.transform.position;
			Destroy(gameObject);
		}
	}
}