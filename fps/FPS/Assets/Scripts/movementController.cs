using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float jumpSpeed = 1f;
    public float gravity = 9.8f;
    float currentSpeed = 0f;
    float vSpeed = 0f;
    public CharacterController playerMovementController;

    void Start()
    {
        playerMovementController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (playerMovementController.isGrounded)
        {
            vSpeed = -gravity * 0.5f * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                vSpeed = jumpSpeed;
            }
        }
        else
        {
            vSpeed -= gravity * 0.5f * Time.deltaTime;
        }

        currentSpeed = isRunning ? runSpeed : walkSpeed;
        Vector3 move = transform.right * x + transform.forward * z;
        move.y = vSpeed;
        Physics.SyncTransforms();
        playerMovementController.Move(move * currentSpeed * Time.deltaTime);
    }
}
