using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    PlayerInventory inventory;

    void Start()
    {
        inventory = GameObject.FindObjectOfType<PlayerInventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pickupabble")
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true;
                    break;
                }
            }
        }
    }
}
