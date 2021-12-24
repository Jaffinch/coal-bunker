using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    public void Move(InputAction.CallbackContext value)
    {
        Vector2 moveDirection = value.ReadValue<Vector2>();


    }

   




}
