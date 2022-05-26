using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;



public class WallMaskController : MonoBehaviour
{
 
    public Dictionary<TileBase, TileBase> tileDictionary = new Dictionary<TileBase, TileBase>();
    public Dictionary<TileBase, TileBase> tileDictionary2 = new Dictionary<TileBase, TileBase>();
    Tilemap map;
    public GameObject player;
    public TileBase[] NormalTiles;
    public TileBase[] TransTiles;
    public Vector3Int[] checkTiles = new Vector3Int[3];
    public Vector3Int[] prevCheckTiles = new Vector3Int[3];

    public TileBase leftTile;
    public TileBase rightTile;
    public TileBase pilTile;
    public TileBase corTile;

    public TileBase transLeftTile;
    public TileBase transRightTile;
    public TileBase transPilTile;
    public TileBase transCorTile;

    private TileBase tile;

    private void Start()
    {
        map = GetComponent<Tilemap>();

        for (int i = 0; i < NormalTiles.Length; i++)
        {
            tileDictionary.Add(NormalTiles[i], TransTiles[i]);
            tileDictionary2.Add(TransTiles[i], NormalTiles[i]);
        }
    }

    private void Update()
    {
        //GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        //Vector3Int cellPosition = gridLayout.WorldToCell(player.transform.position);
        //map.SetTile(cellPosition, transparent);
        
        Vector3Int lPos = map.WorldToCell(player.transform.position);
        // map.SetTile(lPos, transparent);

        SetCheckTiles(lPos);


        if (map.GetTile(checkTiles[1]) == leftTile)
        {
            map.SetTile(checkTiles[1], transLeftTile);
        }
        
        if(map.GetTile(checkTiles[0]) == leftTile)
        {
            map.SetTile(checkTiles[0], transLeftTile);
        }
        else if (map.GetTile(checkTiles[0]) == rightTile)
        {
            map.SetTile(checkTiles[0], transRightTile);
        }
        else if (map.GetTile(checkTiles[0]) == pilTile)
        {
            map.SetTile(checkTiles[0], transPilTile);
        }
        else if (map.GetTile(checkTiles[0]) == corTile)
        {
            map.SetTile(checkTiles[0], transCorTile);
        }

        if(map.GetTile(checkTiles[2]) == rightTile)
        {
            map.SetTile(checkTiles[2], transRightTile);
        }


        for (int i = 0; i < prevCheckTiles.Length; i++)
        {
            if (!checkTiles.Contains(prevCheckTiles[i]))
            {
                if (map.GetTile(prevCheckTiles[i]) == transLeftTile)
                {
                    map.SetTile(prevCheckTiles[i], leftTile);
                }
                else if (map.GetTile(prevCheckTiles[i]) == transRightTile)
                {
                    map.SetTile(prevCheckTiles[i], rightTile);
                }
                else if (map.GetTile(prevCheckTiles[i]) == transPilTile)
                {
                    map.SetTile(prevCheckTiles[i], pilTile);
                }
                else if (map.GetTile(prevCheckTiles[i]) == transCorTile)
                {
                    map.SetTile(prevCheckTiles[i], corTile);
                }
            }

        }
        



        /*     for (int i = 0; i < checkTiles.Length; i++)
         {
             if (tileDictionary.TryGetValue(map.GetTile(checkTiles[i]), out tile))
             {
                 map.SetTile(checkTiles[i], tile);
             }
             if (!checkTiles.Contains(prevCheckTiles[i]))
             {
                 if (tileDictionary2.TryGetValue(map.GetTile(prevCheckTiles[i]), out tile))
                 {
                     map.SetTile(prevCheckTiles[i], tile);
                 }
             }
             prevCheckTiles[i] = checkTiles[i];
         }
         */



        Debug.Log(lPos);
    }

    void SetCheckTiles(Vector3Int lPos)
    {
        //Mid Tile
        prevCheckTiles[0] = checkTiles[0];
        //left tile
        prevCheckTiles[1] = checkTiles[1];
        //right tile
        prevCheckTiles[2] = checkTiles[2];
        checkTiles[0] = new Vector3Int(lPos.x - 1 , lPos.y -1 , 0);
        checkTiles[1] = new Vector3Int(lPos.x - 1, lPos.y, 0);
        checkTiles[2] = new Vector3Int(lPos.x, lPos.y - 1, 0);

    }




}
