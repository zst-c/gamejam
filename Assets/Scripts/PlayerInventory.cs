using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            slots[0].GetComponent<InventorySlot>().DropItem();
        }
        if (Input.GetKey(KeyCode.E))
        {
            slots[1].GetComponent<InventorySlot>().DropItem();
        }
        if (Input.GetKey(KeyCode.R))
        {
            slots[2].GetComponent<InventorySlot>().DropItem();
        }
        if (Input.GetKey(KeyCode.T))
        {
            slots[3].GetComponent<InventorySlot>().DropItem();
        }
    }
}
