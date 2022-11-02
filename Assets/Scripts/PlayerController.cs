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
        Vector2 moveInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (!isMoving && Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            StartCoroutine(MovePlayer(moveInput));
        }
    }

    void FixedUpdate()
    {
        
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
