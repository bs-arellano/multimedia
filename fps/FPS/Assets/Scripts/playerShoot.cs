using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject bulletPrefab;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 direction = hit.point - playerCamera.transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                float spawnDistance = 1.0f;
                Vector3 spawnPosition = playerCamera.transform.position + direction.normalized * spawnDistance;
                Instantiate(bulletPrefab, spawnPosition, rotation);
            }
        }
    }
}
