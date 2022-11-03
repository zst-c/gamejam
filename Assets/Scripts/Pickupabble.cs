using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupabble : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject pickupSfx = null;
    PlayerInventory inventory;
    [SerializeField] GameObject itemButton;
    public Level1Controller levelController;

    private void Start()
    {
        inventory = GameObject.FindObjectOfType<PlayerInventory>();
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < .5)
        {
            Instantiate(pickupSfx, transform.position, Quaternion.identity);
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                levelController.PickUpBerry();
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
                Destroy(gameObject);
            }
        }
    }
}
