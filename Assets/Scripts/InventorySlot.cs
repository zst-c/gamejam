using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    PlayerInventory inventory;
    public int i;

    void Start()
    {
        inventory = GameObject.FindObjectOfType<PlayerInventory>();
    }

    void Update()
    {
        if (transform.childCount <= 1)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("PickupSlot"))
            {
                child.GetComponent<SpawnDroppedItem>().SpawnItem();
                Destroy(child.gameObject);
            }
        }
    }


}
