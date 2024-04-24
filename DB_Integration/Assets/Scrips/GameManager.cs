using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public GameObject pipe;
    public GameObject gameOver;
    public Text textScore;
    public Text endScore;
    public Text highScore;
    private float gameVelocity;
    private int score;
    private float timeSlapsed;
    public void Start()
    {
        timeSlapsed = 0;
        score = 0;
        gameVelocity = 5;
        SpawnPipe();
        gameOver.SetActive(false);
        StartCoroutine(increaseVelocity());
    }
    public float getRandomHeight()
    {
        return Random.Range(-2, 2);
    }
    public float getVelocity()
    {
        return gameVelocity;
    }
    public void endGame()
    {
        gameVelocity = 0;
        endScore.text = "Score: " + score.ToString();
        int highscore = PlayerPrefs.GetInt("highscore");
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", score);
            StartCoroutine(Upload(PlayerPrefs.GetString("currentplayer"), highscore));
        }
        highScore.text = "High Score: " + highscore.ToString();
        gameOver.SetActive(true);
    }
    public void SpawnPipe()
    {
        Instantiate(pipe, position: new Vector3(10, getRandomHeight(), 0), rotation: Quaternion.identity);
    }
    public void Score()
    {
        score += 1;
        textScore.text = score.ToString();
    }
    public void Retry()
    {
        SceneManager.LoadScene("main");
    }
    public void Exit()
    {
        SceneManager.LoadScene("menu");
    }
    IEnumerator Upload(string name, int score)
    {
        using (UnityWebRequest request = UnityWebRequest.Post("http://localhost:3000/highscore", $"{{\"name\": \"{name}\",\"score\": {score}}}", "application/json"))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
                yield break;
            }
            else
            {
                Debug.Log("Data successfully sended");
                yield return null;
            }
        }
    }

    IEnumerator increaseVelocity()
    {
        while (gameVelocity < 15)
        {
            gameVelocity += 10 / 300;
            timeSlapsed += 1;
            yield return new WaitForSeconds(1);
        }

    }
}

