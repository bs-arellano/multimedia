using UnityEngine;

public class PipeController : MonoBehaviour
{
    private float velocity;
    private GameManager gameManager;
    public bool spawned;
    public bool scored;
    void Start()
    {
        scored = false;
        spawned = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        velocity = gameManager.getVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velocity * Time.deltaTime;
        if (transform.position.x < 0 && !spawned)
        {
            gameManager.SpawnPipe();
            spawned = true;
        }
        if (transform.position.x<-6 && !scored){
            gameManager.Score();
            scored = true;
        }
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.CompareTag("Player"))
        {
            Destroy(collision2D.gameObject);
            gameManager.endGame();
        }
    }
}
