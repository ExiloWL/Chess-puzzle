using UnityEngine;
using System.Collections.Generic;

public class RookMovement : MonoBehaviour
{
    public List<Vector2Int> GetValidMoves(Vector2Int currentPos, int boardSize)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        // Horizontal and vertical movement
        for (int i = 0; i < boardSize; i++)
        {
            validMoves.Add(new Vector2Int(i, currentPos.y)); // Horizontal line
            validMoves.Add(new Vector2Int(currentPos.x, i)); // Vertical line
        }

        return validMoves;
    }
}
