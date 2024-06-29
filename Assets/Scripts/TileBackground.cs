using UnityEngine;

public class TileBackground : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab to tile
    public int tilesX = 10; // Number of tiles in the X direction
    public int tilesY = 10; // Number of tiles in the Y direction

    void Start()
    {
        Vector2 tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;

        for (int x = -tilesX; x <= tilesX; x++)
        {
            for (int y = -tilesY; y <= tilesY; y++)
            {
                Vector3 pos = new Vector3(x * tileSize.x, y * tileSize.y, transform.position.z);
                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                tile.transform.parent = transform;
            }
        }
    }
}
