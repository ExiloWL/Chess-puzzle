using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public Vector2Int currentPosition;
    public abstract void CalculateValidMoves(int boardSize);
}
