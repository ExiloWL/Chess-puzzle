using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab for each tile on the chessboard
    public Material lightMaterial; // Material for light-colored tiles
    public Material darkMaterial; // Material for dark-colored tiles
    public int boardSize = 16; // Size of the board (16x16)

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < boardSize; x++)
        {
            for (int z = 0; z < boardSize; z++)
            {
                Vector3 position = new Vector3(x, 0, z);
                
                // Instantiate the tile prefab
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                
                // Assign a material based on the position to create the checkerboard pattern
                Renderer tileRenderer = tile.GetComponent<Renderer>();
                if ((x + z) % 2 == 0)
                {
                    tileRenderer.material = lightMaterial; // Light-colored tile
                }
                else
                {
                    tileRenderer.material = darkMaterial; // Dark-colored tile
                }

                // Name the tile based on its coordinates
                char letter = (char)('A' + x); // Letters from A to P (16x16 board)
                int number = boardSize - z; // Numbers from 16 down to 1
                tile.name = $"{letter}{number}";
            }
        }
    }
}
