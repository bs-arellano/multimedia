
using UnityEngine;
[System.Serializable]
public class PlayerScore
{
    public string _id;
    public string username;
    public int score;
    public string date;
    public int __v;
    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }
    public static PlayerScore Parse(string json)
    {
        return JsonUtility.FromJson<PlayerScore>(json);
    }
}
