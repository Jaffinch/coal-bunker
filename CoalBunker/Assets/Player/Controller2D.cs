using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Controller2D : MonoBehaviour
{
 

    //num of rays to cast
    public int horizontalRayCount = 3;
    public int verticalRayCount = 3;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    PolygonCollider2D polyCollider;
    RaycastOrigins raycastOrigins;

    private void Start()
    {
        polyCollider = GetComponent<PolygonCollider2D>();
        CalculateRaySpacing();
    }

    public void CheckCollisions()
    {
        UpdateRaycastOrigins();
        VerticalCollisions();
    }

    void VerticalCollisions()
    {
        Debug.DrawRay(raycastOrigins.midBot, (Vector2.up + Vector2.left + Vector2.left).normalized * -2, Color.red);
        Debug.DrawRay(raycastOrigins.midBot, (Vector2.up + Vector2.right + Vector2.right).normalized * -2, Color.red);
        Debug.DrawRay(raycastOrigins.midTop, (Vector2.down + Vector2.left + Vector2.left).normalized * -2, Color.red);
        Debug.DrawRay(raycastOrigins.midTop, (Vector2.down + Vector2.right + Vector2.right).normalized * -2, Color.red);
        Debug.DrawRay(raycastOrigins.midRight, (Vector2.down + Vector2.left + Vector2.left).normalized * -2, Color.red);
        Debug.DrawRay(raycastOrigins.midRight, (Vector2.up + Vector2.left + Vector2.left).normalized * -2, Color.red);
        Debug.DrawRay(raycastOrigins.midLeft, (Vector2.down + Vector2.right + Vector2.right).normalized * -2, Color.red);
        Debug.DrawRay(raycastOrigins.midLeft, (Vector2.up + Vector2.right + Vector2.right).normalized * -2, Color.red);


        /*for (int i = 0; i < verticalRayCount; i++)
        {
            Debug.DrawRay((raycastOrigins.botRight + raycastOrigins.botLeft)/2 + (Vector2.up + Vector2.right + Vector2.right).normalized * verticalRaySpacing * i, (Vector2.up + Vector2.right + Vector2.right).normalized * -2, Color.red);
            
            //Debug.DrawRay(raycastOrigins.botLeft + (Vector2.up + Vector2.right).normalized * horizontalRaySpacing * i, (Vector2.up + Vector2.right).normalized * -2, Color.red);
        }*/
    }

    void UpdateRaycastOrigins()
    {
        
        //gets the size of our collider
        Bounds bounds = polyCollider.bounds;

        //gets the position of the corners of our collider
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        raycastOrigins.botLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.botRight = new Vector2(bounds.max.x, bounds.min.y);

        raycastOrigins.midBot = new Vector2(raycastOrigins.botRight.x + ((raycastOrigins.botLeft.x - raycastOrigins.botRight.x)/2), raycastOrigins.botLeft.y);
        raycastOrigins.midTop = new Vector2(raycastOrigins.topRight.x + ((raycastOrigins.topLeft.x - raycastOrigins.topRight.x) / 2), raycastOrigins.topLeft.y);
        raycastOrigins.midRight = new Vector2(raycastOrigins.topRight.x, raycastOrigins.topRight.y + ((raycastOrigins.botRight.y - raycastOrigins.topRight.y) / 2));
        raycastOrigins.midLeft = new Vector2(raycastOrigins.topLeft.x, raycastOrigins.topLeft.y + ((raycastOrigins.botLeft.y - raycastOrigins.topLeft.y) / 2));


        Debug.DrawRay(raycastOrigins.botLeft, Vector2.up, Color.green);
        Debug.DrawRay(raycastOrigins.topLeft, Vector2.right, Color.green);
        Debug.DrawRay(raycastOrigins.topRight, Vector2.down, Color.green);
        Debug.DrawRay(raycastOrigins.botRight, Vector2.left, Color.green);

    }


    void CalculateRaySpacing()
    {
        //gets the size of our collider
        Bounds bounds = polyCollider.bounds;


        //Set the number of rays to at least 2
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);

        //set distance between rays
        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount- 1);

    }

    //box collider co-ordinates
    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 botLeft, botRight;

        public Vector2 midBot, midTop;
        public Vector2 midLeft, midRight;
    }
}
