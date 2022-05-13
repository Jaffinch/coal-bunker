using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Controller2D : MonoBehaviour
{
 

    //num of rays to cast
    public int rayCount;
    public float rayLength;
    public Vector2 rayOrigin;
    public Vector2 rayDirection;
    public LayerMask collisionMask;


    PolygonCollider2D polyCollider;

    RaycastOrigins raycastOrigins;
    Vector2Diagonals v2Diags;

    private void Start()
    {
        polyCollider = GetComponent<PolygonCollider2D>();

        v2Diags.downLeft = (Vector2.down + Vector2.left + Vector2.left).normalized;
        v2Diags.downRight = (Vector2.down + Vector2.right + Vector2.right).normalized;
        v2Diags.upLeft = (Vector2.up + Vector2.left + Vector2.left).normalized;
        v2Diags.upRight = (Vector2.up + Vector2.right + Vector2.right).normalized;
    }

    public void CheckCollisions(Vector2 velocity)
    {
        UpdateRaycastOrigins();
        SetRaycastStartVariables(velocity);
        RaycastCollisions(ref velocity);
        MovePlayer(velocity);
    }


    void MovePlayer(Vector2 velocity)
    {
        
        transform.Translate(velocity);
    }

    void SetRaycastStartVariables(Vector2 velocity)
    {

        //ray origin and direction
        //1 o clock
        if(velocity.x > 0 && velocity.y > 0)
        {
            rayOrigin = raycastOrigins.midTop;
            rayDirection = v2Diags.upRight;
            rayCount = 2;
        }
        //3 o clock
        else if(velocity.x > 0 && velocity.y == 0)
        {
            rayOrigin = raycastOrigins.midTop;
            rayDirection = v2Diags.upRight;
            rayCount = 4;

        }
        //4 o clock
        else if(velocity.x > 0 && velocity.y < 0)
        {
            rayOrigin = raycastOrigins.midRight;
            rayDirection = v2Diags.downRight;
            rayCount = 2;
        }
        //6 o clock
        else if(velocity.x == 0 && velocity.y < 0)
        {
            rayOrigin = raycastOrigins.midRight;
            rayDirection = v2Diags.downRight;
            rayCount = 4;
        }
        //7 o clock
        else if (velocity.x < 0 && velocity.y < 0)
        {
            rayOrigin = raycastOrigins.midBot;
            rayDirection = v2Diags.downLeft;
            rayCount = 2;
        }
        //9 o clock
        else if (velocity.x < 0 && velocity.y == 0)
        {
            rayOrigin = raycastOrigins.midBot;
            rayDirection = v2Diags.downLeft;
            rayCount = 4;
        }
        //10 o clock
        else if (velocity.x < 0 && velocity.y > 0)
        {
            rayOrigin = raycastOrigins.midLeft;
            rayDirection = v2Diags.upLeft;
            rayCount = 2;
        }
        //12 o clock
        else if (velocity.x == 0 && velocity.y > 0)
        {
            rayOrigin = raycastOrigins.midLeft;
            rayDirection = v2Diags.upLeft;
            rayCount = 4;
        }
        else
        {
            rayCount = 0;
        }


    }

    void RaycastCollisions(ref Vector2 velocity)
    {
        float directionX = Mathf.Sign(velocity.x); ;
        float directionY = Mathf.Sign(velocity.y); ;

        rayLength = (Mathf.Abs(velocity.x) >= Mathf.Abs(velocity.y)) ? Mathf.Abs(velocity.x) : Mathf.Abs(velocity.y);
 
        for (int i = 0; i < rayCount; i++)
        {
            Debug.DrawRay(rayOrigin, rayDirection, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayLength, collisionMask);
            if (hit)
            {
                velocity.x = 0;
                velocity.y = 0;
                rayLength = hit.distance;
            }

            SetNextRay(i);
        }

    }

    void SetNextRay(int i)
    {
        if(i == 1)
        {
            if(rayDirection == v2Diags.downLeft)
            {
                rayDirection = v2Diags.upLeft;
            }
            else if(rayDirection == v2Diags.upLeft)
            {
                rayDirection = v2Diags.upRight;
            }
            else if (rayDirection == v2Diags.upRight)
            {
                rayDirection = v2Diags.downRight;
            }
            else if (rayDirection == v2Diags.downRight)
            {
                rayDirection = v2Diags.downLeft;
            }
        }
        else
        {
            if (rayOrigin == raycastOrigins.midBot)
            {
                rayOrigin = raycastOrigins.midLeft;
            }
            else if (rayOrigin == raycastOrigins.midLeft)
            {
                rayOrigin = raycastOrigins.midTop;
            }
            else if (rayOrigin == raycastOrigins.midTop)
            {
                rayOrigin = raycastOrigins.midRight;
            }
            else if (rayOrigin == raycastOrigins.midRight)
            {
                rayOrigin = raycastOrigins.midBot;
            }
        }

        

    }

    void UpdateRaycastOrigins()
    {
        
        //gets the size of our collider
        Bounds bounds = polyCollider.bounds;

        //find the mid points of collider bounds
        raycastOrigins.midBot = new Vector2(bounds.max.x + ((bounds.min.x - bounds.max.x) /2), bounds.min.y);
        raycastOrigins.midTop = new Vector2(bounds.max.x + ((bounds.min.x - bounds.max.x) / 2), bounds.max.y);
        raycastOrigins.midRight = new Vector2(bounds.max.x, bounds.max.y + ((bounds.min.y - bounds.max.y) / 2));
        raycastOrigins.midLeft = new Vector2(bounds.min.x, bounds.max.y + ((bounds.min.y - bounds.max.y) / 2));

        /*
        Debug.DrawRay(raycastOrigins.botLeft, Vector2.up, Color.green);
        Debug.DrawRay(raycastOrigins.topLeft, Vector2.right, Color.green);
        Debug.DrawRay(raycastOrigins.topRight, Vector2.down, Color.green);
        Debug.DrawRay(raycastOrigins.botRight, Vector2.left, Color.green);
        */
    }


    //box collider co-ordinates
    struct RaycastOrigins
    {
        public Vector2 midBot, midTop, midLeft, midRight;

    }

    struct Vector2Diagonals
    {
        public Vector2 upLeft, upRight, downLeft, downRight;
    }


}
