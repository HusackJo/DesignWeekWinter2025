using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 moveDirection { get; private set; }
    private CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GatherInputs();
    }

    private void LateUpdate()
    {
        charController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void GatherInputs()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveInput.magnitude > 1)
        {
            moveInput = moveInput.normalized;
        }

        moveDirection = moveInput;

        //add attacks!
    }

    private Vector2 GetMoveDirection()
    {
        return moveDirection;
    }
}
