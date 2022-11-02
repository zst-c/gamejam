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

    void Start()
    {
        movePoint.parent = null;
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
        // if (!isMoving)
        // {
        //     if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //     {
        //         StartCoroutine(MovePlayer(Vector2.up));
        //     }
        //     if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //     {
        //         StartCoroutine(MovePlayer(Vector2.left));
        //     }
        //     if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //     {
        //         StartCoroutine(MovePlayer(Vector2.down));
        //     }
        //     if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //     {
        //         StartCoroutine(MovePlayer(Vector2.right));
        //     }
        // }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, playerMovementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), .2f, whatLayerStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), .2f, whatLayerStopsMovement))
                {
                    movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                }
            }
        }
    }

    // IEnumerator MovePlayer(Vector2 direction)
    // {
    //     isMoving = true;
    //     float elapsedTime = 0;
    //     originPosition = transform.position;
    //     targetPosition = originPosition + direction;
    //     while (elapsedTime < timeToMoveBetweenTheSpacesInTheGrid)
    //     {
    //         transform.position = Vector2.Lerp(originPosition, targetPosition, (elapsedTime / timeToMoveBetweenTheSpacesInTheGrid));
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }
    //     transform.position = targetPosition;
    //     isMoving = false;
    // }
}
