using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour
{

    Vector2 velocity;

    public Rigidbody2D rb;
    public Animator anim;

    public float walkSpeed;

    private float directionX;
    private float directionY;
    private float prevX;
    private float prevY;


    private void FixedUpdate()
    {

        rb.velocity = velocity * Time.deltaTime;

        directionX = velocity.x;
        directionY = velocity.y;

        if (directionX == 0 && directionY == 0)
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

    public void GetMovementInput(InputAction.CallbackContext value)
    {
        Vector2 inputDirection =  value.ReadValue<Vector2>();
        if(inputDirection.y == 0)
        {
            velocity.x = inputDirection.x * walkSpeed/2;
            velocity.y = 0;
 
        }
        else if(inputDirection.x == 0)
        {
            velocity.x = 0;
            velocity.y = inputDirection.y * walkSpeed / 2;
        }
        else
        {
            velocity.x = inputDirection.x * walkSpeed / 2;
            velocity.y = inputDirection.y * walkSpeed / 4;
        }

    }

}
