using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    string currentSceneName;
    public int vidas = 3;
    string goalTag = "goal";
    string enemyTag = "enemy";
    GameObject[] respawns;
    Transform respawnTransform;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Instance.currentSceneName = SceneManager.GetActiveScene().name;
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        respawnTransform = respawns[0].transform;
        Instance.transform.position = respawnTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(goalTag))
        {
            Debug.Log(currentSceneName);
            if (currentSceneName.Equals("basic"))
            {
                LoadNextScene("maze 1");
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                LoadNextScene("menu");
                Destroy(gameObject);
            }
        }
        if (other.CompareTag(enemyTag))
        {
            vidas -= 1;
            if (vidas > 0)
            {
                while (respawnTransform == null){
                    Debug.Log("No respawn found");
                    respawns = GameObject.FindGameObjectsWithTag("Respawn");
                    respawnTransform = respawns[0].transform;
                    Debug.Log("New respawn on"+respawnTransform.position);
                }
                transform.position = respawnTransform.position;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                LoadNextScene("menu");
                Destroy(gameObject);
            }
        }
    }

    private void LoadNextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
