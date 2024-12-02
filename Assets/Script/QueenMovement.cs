using UnityEngine;
using System.Collections.Generic;

public class QueenMovement : MonoBehaviour
{
    public LayerMask squareLayer; // Layer to detect squares
    public Color highlightColor = Color.yellow; // Highlight color
    private List<GameObject> validSquares = new List<GameObject>(); // List of valid squares for queen movement
    private Color originalColor; // To store the original color of the squares

    void Start()
    {
        // Store the original color of the squares when the game starts
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the queen was clicked
                if (hit.collider.CompareTag("Queen"))
                {
                    // Queen clicked, now highlight valid squares
                    Debug.Log("Queen clicked!");
                    HighlightValidSquares();
                }
                // Check if a square was clicked
                else if (hit.collider.CompareTag("Square"))
                {
                    GameObject square = hit.collider.gameObject;

                    // If clicked on a valid square, move the queen there
                    if (validSquares.Contains(square))
                    {
                        MoveQueen(square);
                    }
                }
            }
        }
    }

    void HighlightValidSquares()
    {
        ClearHighlights(); // Clear previous highlights
        validSquares.Clear(); // Clear the valid squares list

        // Directions the queen can move (8 directions)
        Vector3[] directions = new Vector3[]
        {
            Vector3.forward, Vector3.back, Vector3.left, Vector3.right,
            Vector3.forward + Vector3.left, Vector3.forward + Vector3.right,
            Vector3.back + Vector3.left, Vector3.back + Vector3.right
        };

        Vector3 queenPosition = transform.position;

        // Highlight squares the queen can move to
        foreach (Vector3 direction in directions)
        {
            RaycastHit[] hits = Physics.RaycastAll(queenPosition, direction, 16f, squareLayer); // Cast a ray to check squares

            foreach (RaycastHit hit in hits)
            {
                GameObject square = hit.collider.gameObject;

                // Only add squares that are not blocked by barriers or other pieces
                if (square.CompareTag("Square")) // Ensure it's a valid square
                {
                    validSquares.Add(square);
                    HighlightSquare(square); // Highlight the valid square
                }
            }
        }
    }

    void HighlightSquare(GameObject square)
    {
        Renderer squareRenderer = square.GetComponent<Renderer>();
        if (squareRenderer != null)
        {
            squareRenderer.material.color = highlightColor; // Change the color to indicate the square is valid
        }
    }

    void ClearHighlights()
    {
        foreach (GameObject square in validSquares)
        {
            Renderer squareRenderer = square.GetComponent<Renderer>();
            if (squareRenderer != null)
            {
                squareRenderer.material.color = Color.white; // Reset the color of the square
            }
        }

        validSquares.Clear(); // Clear the list of valid squares
    }

    void MoveQueen(GameObject square)
    {
        // Move the queen to the selected square
        transform.position = square.transform.position;
        ClearHighlights(); // Remove highlights after moving
    }
}
