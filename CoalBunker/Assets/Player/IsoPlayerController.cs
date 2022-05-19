using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IsoPlayerController : MonoBehaviour
{

    private Animator anim;



    private float directionX;
    private float directionY;
    private float prevX;
    private float prevY;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void IsometricMove(Vector2 movement)
    {
        CartesianToIsometric(movement);

    }


    void CartesianToIsometric(Vector2 cartesian)
    {
        Vector2 isometric = transform.position;
        isometric.x =+ (cartesian.x - cartesian.y);
        isometric.y =+ (cartesian.x  + cartesian.y) / 2;

        directionX = isometric.x;
        directionY = isometric.y;

        transform.Translate(isometric);
    }

    void Update()
    {


        if(directionX == 0 && directionY == 0)
        {
            anim.SetFloat("PosX", prevX);
            anim.SetFloat("PosY", prevY);
        }
        else
        {
            anim.SetFloat("PosX", directionX);
            anim.SetFloat("PosY", directionY);
            prevX = directionX;
            prevY = directionY;

        }
        
    }

}
