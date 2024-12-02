using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public Vector2Int currentPosition;  // Current position of the piece on the board.
    public float moveSpeed = 5f;        // Speed at which the piece moves.
    public float tileSpacing = 2f;      // The spacing between tiles on the board (adjust this to match your board size).

    private Vector3 targetPosition;     // The target position the piece should move to.
    private bool isMoving = false;      // Is the piece currently moving?

    void Update()
    {
        HandleInput();
        MovePiece();
    }

    // Handle input to move the piece.
    void HandleInput()
    {
        if (isMoving)
            return;

        if (Input.GetKeyDown(KeyCode.W)) // Move up
        {
            targetPosition = new Vector3(currentPosition.x * tileSpacing, 0, (currentPosition.y + 1) * tileSpacing);
            currentPosition.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.S)) // Move down
        {
            targetPosition = new Vector3(currentPosition.x * tileSpacing, 0, (currentPosition.y - 1) * tileSpacing);
            currentPosition.y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.A)) // Move left
        {
            targetPosition = new Vector3((currentPosition.x - 1) * tileSpacing, 0, currentPosition.y * tileSpacing);
            currentPosition.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D)) // Move right
        {
            targetPosition = new Vector3((currentPosition.x + 1) * tileSpacing, 0, currentPosition.y * tileSpacing);
            currentPosition.x += 1;
        }

        isMoving = true; // Start moving when input is received.
    }

    // Smoothly move the piece to the target position.
    void MovePiece()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Once the piece reaches the target position, stop moving.
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
