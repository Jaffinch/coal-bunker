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

    Vector2 velocity;

    //physics scripts
    Controller2D controller;

    private void Start()
    {
        controller = GetComponent<Controller2D>();
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        //move player
        transform.Translate(directionX * moveSpeed * Time.deltaTime, directionY * moveSpeed * Time.deltaTime, 0);
    }

    public void Move(InputAction.CallbackContext value)
    {
        Vector2 moveDirection = value.ReadValue<Vector2>();

        directionX =  moveDirection.x;
        directionY =  moveDirection.y;

    }

   




}
