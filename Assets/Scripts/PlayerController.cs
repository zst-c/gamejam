using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMovementSpeed = 5f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask whatLayerStopsMovement;

    [SerializeField] GameMemory memory;

    // index into game memory where x and y are stored
    private const int xPtr = 0, yPtr = 1;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, playerMovementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            memory.ChangeMemory(() => {
                memory.memory[xPtr] = (byte)transform.position.x;
                memory.memory[yPtr] = (byte)transform.position.y;
            });
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
}
