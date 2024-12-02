using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public PlayerPiece playerPiece;
    public EnemyPiece enemyPiece;

    void Update()
    {
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (playerPiece.currentPosition == enemyPiece.currentPosition)
        {
            Debug.Log("You Win!");
            // Implement win behavior, like changing scene or showing a UI.
        }
    }
}
