using UnityEngine;
using System.Collections.Generic;

public class QueenTest : MonoBehaviour
{
    public Color highlightColor = Color.yellow; // Highlight color for valid squares
    private List<GameObject> highlightedSquares = new List<GameObject>(); // List to track highlighted squares

    void Start()
    {
        // Initial setup, if necessary
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // If we clicked the Queen, log it and highlight squares
                if (hit.collider.CompareTag("Queen"))
                {
                    Debug.Log("Queen clicked!");
                    HighlightSquares(); // Call function to highlight valid squares
                }

                // If we clicked a square, highlight it and log it
                else if (hit.collider.CompareTag("Square"))
                {
                    GameObject square = hit.collider.gameObject;
                    HighlightSquare(square); // Highlight the clicked square
                    Debug.Log("Square clicked: " + square.name);
                }
            }
        }
    }

    void HighlightSquares()
    {
        // Clear the previous highlights
        ClearHighlightedSquares();

        // Example: Highlight squares in certain directions (just forward for now)
        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.forward, 16f);
        foreach (RaycastHit hit in hits)
        {
            GameObject square = hit.collider.gameObject;
            HighlightSquare(square);
        }
    }

    void HighlightSquare(GameObject square)
    {
        Renderer squareRenderer = square.GetComponent<Renderer>();
        if (squareRenderer != null)
        {
            squareRenderer.material.color = highlightColor; // Highlight the square
            highlightedSquares.Add(square); // Add it to the highlighted list
        }
    }

    void ClearHighlightedSquares()
    {
        // Reset the color of all previously highlighted squares
        foreach (GameObject square in highlightedSquares)
        {
            Renderer squareRenderer = square.GetComponent<Renderer>();
            if (squareRenderer != null)
            {
                squareRenderer.material.color = Color.white; // Reset the color
            }
        }

        // Clear the list of highlighted squares
        highlightedSquares.Clear();
    }
}
