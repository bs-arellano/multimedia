using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAnimation : MonoBehaviour
{
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
