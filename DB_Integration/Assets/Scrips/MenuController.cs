using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    public Text playerName;
    public Text top;
    public void Start()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(GetTop());
    }
    public void Play()
    {
        string name = playerName.text;
        if (name.Equals(""))
        {
            name = "jugador1";
        }
        PlayerPrefs.SetString("currentplayer", name);
        SceneManager.LoadScene("main");
    }

    IEnumerator GetTop()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/top"))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
                yield break;
            }
            string jsonResponse = request.downloadHandler.text;
            string topScores = "TOP\n";
            PlayerScoreList scoreList = JsonUtility.FromJson<PlayerScoreList>("{\"scores\":" + jsonResponse + "}");
            List<PlayerScore> scores = scoreList.scores;
            foreach (PlayerScore scoreData in scores)
            {
                topScores += $"{scoreData.username} {scoreData.score}\n";
            }
            top.text = topScores;
        }
    }
}

public class PlayerScoreList
{
    public List<PlayerScore> scores;
}