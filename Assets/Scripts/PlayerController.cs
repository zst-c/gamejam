using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float timeToMoveBetweenTheSpacesInTheGrid = 0.2f;
    Vector2 originPosition, targetPosition;
    bool isMoving;

    void Start()
    {

    }

    void Update()
    {
        // Bro what the fuck is happening, it works, but just sometimes
        // Vector2 moveInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // if (!isMoving && Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        // {
        //     StartCoroutine(MovePlayer(moveInput));
        // }

        // Scuff implementation but it works I guess
        if (!isMoving)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                StartCoroutine(MovePlayer(Vector2.up));
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine(MovePlayer(Vector2.left));
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine(MovePlayer(Vector2.down));
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine(MovePlayer(Vector2.right));
            }
        }
    }

    IEnumerator MovePlayer(Vector2 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        originPosition = transform.position;
        targetPosition = originPosition + direction;
        while (elapsedTime < timeToMoveBetweenTheSpacesInTheGrid)
        {
            transform.position = Vector2.Lerp(originPosition, targetPosition, (elapsedTime / timeToMoveBetweenTheSpacesInTheGrid));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }
}
