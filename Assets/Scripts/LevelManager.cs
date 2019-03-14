using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]private GameObject[] tilePrefabs;

    public float TileSize
    {
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel()
    {
        string[] mapData = new string[]
        {
            "0000", "1111", "2222", "3333"
        };
        int mapSizeX = mapData[0].ToCharArray().Length;
        int mapSizeY = mapData.Length;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y = 0; y < mapSizeY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();
            for (int x = 0; x < mapSizeX; x++)
            {
                PlaceTile(newTiles[x].ToString(), y, x, worldStart);
            }
        }
    }

    private void PlaceTile(string tileType, int y, int x, Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);
        GameObject newTile = Instantiate(tilePrefabs[tileIndex]);
        newTile.transform.position = new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0);
    }
}
