using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (Controller2D))]
public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 1f;
    private float directionX;
    private float directionY;

    //temps to be deleted
    private float prevX;
    private float prevY;

    Vector2 velocity;

    //physics scripts
    Controller2D controller;
    Animator anim;

    private void Start()
    {
        controller = GetComponent<Controller2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        controller.CheckCollisions();
    }

    private void LateUpdate()
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
        


        //move player
        if ((directionX > 0 || directionX < 0) && (directionY > 0 || directionY < 0))
        {
            transform.Translate(directionX * moveSpeed * Time.deltaTime, directionY * moveSpeed * Time.deltaTime/2, 0);
        }
        else
        {
            transform.Translate(directionX * moveSpeed * Time.deltaTime * 0.75f, directionY * moveSpeed * Time.deltaTime * 0.75f, 0);
        }
        
    }

    public void Move(InputAction.CallbackContext value)
    {
        Vector2 moveDirection = value.ReadValue<Vector2>();

        directionX =  moveDirection.x;
        directionY =  moveDirection.y;

    }

   




}