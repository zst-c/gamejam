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
        Instantiate(item, spawnPos, Quaternion.identity);

        var levelController = GameObject.FindObjectOfType<Level1Controller>();
        item.GetComponent<Pickupabble>().levelController = levelController;
    }
}
