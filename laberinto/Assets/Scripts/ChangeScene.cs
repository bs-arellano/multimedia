using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("basic");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("maze 1");
    }
}
