using UnityEngine;

public class EnemyPiece : MonoBehaviour
{
    public Vector2Int currentPosition;

    // Placeholder for enemy logic (no AI, just a win condition)
    public void SetPosition(Vector2Int position)
    {
        transform.position = new Vector3(position.x * 2f, 0, position.y * 2f);
        currentPosition = position;
    }
}
