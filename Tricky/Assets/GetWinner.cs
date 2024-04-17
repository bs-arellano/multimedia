using UnityEngine.UI;
using UnityEngine;

public class GetWinner : MonoBehaviour
{
    public Sprite XImage;
    public Sprite OImage;
    // Start is called before the first frame update
    void Start()
    {
        string winner = PlayerPrefs.GetString("last_winner");
        if (winner.Equals("x"))
        {
            GameObject.Find("GanadorImagen").GetComponent<Image>().sprite = XImage;
        }
        else if (winner.Equals("o"))
        {
            GameObject.Find("GanadorImagen").GetComponent<Image>().sprite = OImage;
        }
        else{
            GameObject.Find("TextoGanador").GetComponent<Text>().text = "Empate";
            Destroy(GameObject.Find("GanadorImagen"));
        }
    }
}
