// using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] float timeToMoveBetweenTheSpacesInTheGrid = 0.2f;
    // Vector2 originPosition, targetPosition;
    // bool isMoving;

    [SerializeField] float playerMovementSpeed = 5f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask whatLayerStopsMovement;
    Animator playerAnimator;

    Vector2 movement;



    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        movePoint.parent = null;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, playerMovementSpeed * Time.deltaTime);

        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(movement.x) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0, 0), .2f, whatLayerStopsMovement))
                {
                    movePoint.position += new Vector3(movement.x, 0, 0);
                }
            }
            else if (Mathf.Abs(movement.y) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, movement.y, 0), .2f, whatLayerStopsMovement))
                {
                    movePoint.position += new Vector3(0, movement.y, 0);
                }
            }
        }
    }
}