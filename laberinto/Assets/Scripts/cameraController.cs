using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float sensityivity = 1f;
    public CharacterController playerMovementController;
    float cameraVerticalRotation = 0f;
    bool lockedCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementController = GetComponentInParent<CharacterController>();
        Cursor.visible = false;
        if (lockedCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        cameraVerticalRotation -= mouseY * sensityivity * 100 * Time.deltaTime;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        playerMovementController.transform.Rotate(Vector3.up * mouseX);
    }
}

