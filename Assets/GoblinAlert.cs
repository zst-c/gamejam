using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;

    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < .5)
        {
            // Show goblin something
            
        }
    }
}
