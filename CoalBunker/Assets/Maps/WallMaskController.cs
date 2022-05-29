using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;



public class WallMaskController : MonoBehaviour
{
    public Tilemap map;
    public GameObject player;
    
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





    private void Update()
    {
        Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, 0);

        Vector3Int lPos = map.WorldToCell(pos);

        SetCheckTiles(lPos);

        //left tile
        if (map.GetTile(checkTiles[1]) == leftTile)
        {
            map.SetTile(checkTiles[1], transLeftTile);
        }
        else if (map.GetTile(checkTiles[1]) == corTile)
        {
            map.SetTile(checkTiles[1], transCorTile);
        }

        //mid tile
        if (map.GetTile(checkTiles[0]) == leftTile)
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

        //right tile
        if(map.GetTile(checkTiles[2]) == rightTile)
        {
            map.SetTile(checkTiles[2], transRightTile);
        }
        else if (map.GetTile(checkTiles[2]) == corTile)
        {
            map.SetTile(checkTiles[2], transCorTile);
        }

        //change tile back
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
    }


    void SetCheckTiles(Vector3Int lPos)
    {
        //Mid Tile
        prevCheckTiles[0] = checkTiles[0];
        //left tile
        prevCheckTiles[1] = checkTiles[1];
        //right tile
        prevCheckTiles[2] = checkTiles[2];
        checkTiles[0] = new Vector3Int(lPos.x - 1, lPos.y - 1, 0);
        checkTiles[1] = new Vector3Int(lPos.x, lPos.y - 1, 0);
        checkTiles[2] = new Vector3Int(lPos.x - 1, lPos.y, 0);

        Debug.Log(lPos);

    }




}
