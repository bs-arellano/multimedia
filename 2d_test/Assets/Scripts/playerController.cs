using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float maxSpeed;
    public bool flipped = false;
    Rigidbody2D playerRB;
    SpriteRenderer playerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_movement = Input.GetAxis("Horizontal");
        if (horizontal_movement > 0 && flipped)
        {
            flip();
        }
        else if (horizontal_movement < 0 && !flipped)
        {
            flip();
        }
    }
    void flip() {

    }
}
