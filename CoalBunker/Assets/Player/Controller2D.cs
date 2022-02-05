using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Controller2D : MonoBehaviour
{
    const float skinWidth = 0.02f;

    //num of rays to cast
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

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
        for (int i = 0; i < verticalRayCount; i++)
        {
            Debug.DrawRay(raycastOrigins.botLeft + Vector2.right * verticalRaySpacing * i, Vector2.up * -2, Color.red);
            Debug.DrawRay(raycastOrigins.botLeft + Vector2.up * horizontalRaySpacing * i, Vector2.right * -2, Color.red);
        }
    }

    void UpdateRaycastOrigins()
    {
        //gets the size of our collider
        Bounds bounds = polyCollider.bounds;
        bounds.Expand(skinWidth * -2);

        //gets the position of the corners of our collider
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        raycastOrigins.botLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.botRight = new Vector2(bounds.max.x, bounds.min.y);
    }


    void CalculateRaySpacing()
    {
        //gets the size of our collider
        Bounds bounds = polyCollider.bounds;
        bounds.Expand(skinWidth * -2);

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
    }
}
