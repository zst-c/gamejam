using UnityEngine;

public class GoblinFollowPlayer : MonoBehaviour
{
    GameObject player;

    private void Start(){
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update(){
        //transform.position.x = player.transform.position.x;
        var pos = gameObject.transform.position;
        pos.x = player.transform.position.x;
        gameObject.transform.position = pos;
    }
}
