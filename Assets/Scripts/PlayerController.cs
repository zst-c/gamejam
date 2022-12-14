using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMovementSpeed = 5f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask whatLayerStopsMovement;
    Animator playerAnimator;

    Vector2 movement;



    [SerializeField] GameMemory memory;

    // index into game memory where x and y are stored
    private const int xPtr = 0, yPtr = 1;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        movePoint.parent = null;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector3 moveAmount = Vector3.MoveTowards(transform.position, movePoint.position, playerMovementSpeed * Time.deltaTime);
        transform.position = moveAmount;

        if (transform.position == movePoint.position)
        {
            playerAnimator.SetBool("isMoving", false);
        }
        else
        {
            playerAnimator.SetBool("isMoving", true);
        }

        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
        if (Mathf.Abs(movement.x) == 1 || Mathf.Abs(movement.y) == 1)
        {
            playerAnimator.SetFloat("Horizontal", movement.x);
            playerAnimator.SetFloat("Vertical", movement.y);
            playerAnimator.SetFloat("LastHorizontal", movement.x);
            playerAnimator.SetFloat("LastVertical", movement.y);
        }

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
            else
            {
                playerAnimator.SetBool("isMoving", false);
            }
        }
    }
}
