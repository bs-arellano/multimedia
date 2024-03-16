using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float destructionTime;
    public float speed = 20f;
    public LayerMask obstacleMask;
    public LifeController lifeController;
    GameObject[] respawns;
    void Start()
    {
        destructionTime = Time.time + 2f;
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
    }
    void Update()
    {
        if (Time.time>destructionTime)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider objectCollider)
    {
        Destroy(gameObject);
        lifeController = objectCollider.gameObject.GetComponent<LifeController>();
        if (lifeController != null)
        {
            lifeController.ReduceLife(40);
            if (lifeController.GetLife()<0)
            {
                ResetPositions();
            }
        }
    }
    void ResetPositions(){
        GameObject playerRef = GameObject.FindGameObjectWithTag("Player");
        playerRef.transform.position = respawns[0].transform.position;
        playerRef.GetComponent<LifeController>().ResetLife();
        GameObject enemyRef = GameObject.FindGameObjectWithTag("Enemy");
        enemyRef.transform.position = respawns[1].transform.position;
        enemyRef.GetComponent<LifeController>().ResetLife();
    }
}
