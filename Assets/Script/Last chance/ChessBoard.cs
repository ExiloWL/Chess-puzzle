using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessboard : MonoBehaviour
{
    public GameObject tilePrefab;
    public int boardSize = 12;
    public float tileSpacing = 2f;
    public Material lightSquareMaterial; // Assign in the inspector
    public Material darkSquareMaterial;  // Assign in the inspector

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                Vector3 position = new Vector3(x * tileSpacing, 0, y * tileSpacing);
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);

                // Alternate colors based on coordinates (x + y)
                if ((x + y) % 2 == 0)
                {
                    tile.GetComponent<Renderer>().material = lightSquareMaterial;
                }
                else
                {
                    tile.GetComponent<Renderer>().material = darkSquareMaterial;
                }
            }
        }
    }
}
