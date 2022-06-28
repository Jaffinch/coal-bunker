using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortOrderController : MonoBehaviour
{
    public Vector3 relativePos;
    public Vector3 pos;
    public Grid g;

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(transform.position.x, transform.position.y, 0);

        Vector3Int tilepos = g.WorldToCell(pos);
        Vector3 tileworldpos = g.CellToWorld(tilepos);
        relativePos = pos - tileworldpos;

        Debug.Log(relativePos);

        if (relativePos.y < .12)
            transform.position = new Vector3(transform.position.x, transform.position.y, 2);
        //else if (relativePos.y < .25)
        //    transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
    }
}
