using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupabble : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("playrr");
        }
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < .5)
        {
            Destroy(gameObject);
        }
    }
}
