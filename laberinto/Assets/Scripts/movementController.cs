using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeeed = 10f;
    public float jumpSpeed = 2f;
    float currentSpeed = 0f;
    public CharacterController playerMovementController;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning)
        {
            currentSpeed = runSpeeed;
        } else
        {
            currentSpeed = walkSpeed;
        }
        Vector3 move = transform.right * x + transform.forward * z;
        playerMovementController.Move(move * currentSpeed * Time.deltaTime);
    }
}
