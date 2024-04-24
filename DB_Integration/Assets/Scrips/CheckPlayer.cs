using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.CompareTag("Player")){
            collision2D.transform.GetComponent<PlayerController>().SetGrounded(true);
        }
    }
    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.transform.CompareTag("Player")){
            collision2D.transform.GetComponent<PlayerController>().SetGrounded(false);
        }
    }
}
