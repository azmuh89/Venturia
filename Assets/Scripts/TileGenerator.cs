using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public Vector2 tileStartPos;
    public int gridWidth, gridHeight;
    Vector2 tileSpacing;

    void Start()
    {
        tileSpacing = tiles[0].GetComponent<Renderer>().bounds.size;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    int randomTile = Random.Range(0, tiles.Length);

                    GameObject go = Instantiate(tiles[randomTile],
                        new Vector3(tileStartPos.x + (j * tileSpacing.x),
                        tileStartPos.y + (i * tileSpacing.y)), Quaternion.identity) as GameObject;

                    go.transform.parent = this.transform;
                }
            }
        }
    }
}
