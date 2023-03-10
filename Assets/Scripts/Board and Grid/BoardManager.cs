using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance { set; get; }
    public List<Sprite> characters = new List<Sprite>();
    public GameObject tile;
    public int xSize, ySize;

    private GameObject[,] _tiles;

    public bool IsShifting { set; get; }
    void Start()
    {
        instance = GetComponent<BoardManager>();

        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateBoard(offset.x, offset.y);
    }

    private void CreateBoard(float offsetX, float offsetY)
    {
        _tiles = new GameObject[xSize, ySize];

        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                GameObject newTile = Instantiate(
                    tile,
                    new Vector3(startX + (offsetX * i), startY + (offsetY * j), 0),
                    tile.transform.rotation);

                _tiles[i, j] = newTile;
                newTile.transform.parent = transform;
                Sprite newTileSprite = characters[Random.Range(0, characters.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = newTileSprite;
            }
        }
    }
}
