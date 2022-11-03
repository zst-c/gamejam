using UnityEngine;

public class SpawnDroppedItem : MonoBehaviour
{
    [SerializeField] GameObject item;
    Transform player;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject.transform;
    }

    public void SpawnItem()
    {
        Vector2 spawnPos = new Vector2(player.position.x, player.position.y + 1);
        GameObject obj = Instantiate(item, spawnPos, Quaternion.identity);
        obj.GetComponent<Key>()?.CheckUnlock();
    }
}
