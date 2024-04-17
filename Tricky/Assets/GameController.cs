using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    List<Transform> boardList = new List<Transform>();
    int[] boardState = new int[9];
    public GameObject board;
    public GameObject turnoImagen;
    public Sprite XImage;
    public Sprite OImage;

    public AudioClip click;
    public AudioClip wrong;
    bool jugador; //true=juegan X, false=juegan O
    int turno;

    int[][] winningCombos = {
        new int [] {0,1,2},
        new int [] {3,4,5},
        new int [] {6,7,8},
        new int [] {0,3,6},
        new int [] {1,4,7},
        new int [] {2,5,8},
        new int [] {0,4,8},
        new int [] {2,4,6}
    };
    // Start is called before the first frame update
    void Start()
    {
        turno = 0;
        jugador = true;
        turnoImagen.GetComponent<Image>().sprite = XImage;
        for (int i = 0; i < 9; i++)
        {
            ;
            boardList.Add(board.transform.Find(i.ToString()));
        }
    }

    public void Turno(int index)
    {
        if (boardState[index] == 0)
        {
            if (jugador)
            {
                boardList[index].GetComponent<Image>().sprite = XImage;
                boardState[index] = 1;
            }
            else
            {
                boardList[index].GetComponent<Image>().sprite = OImage;
                boardState[index] = 2;
            }
            GetComponent<AudioSource>().clip = click;
            GetComponent<AudioSource>().Play();
            boardList[index].GetComponent<Image>().color = Color.white;

            if (checkWinner())
            {
                string last_winner = jugador ? "x" : "o";
                PlayerPrefs.SetString("last_winner", last_winner);
                SceneManager.LoadScene("End");
            }

            jugador = !jugador;
            turno++;
            if (turno >= 9){
                PlayerPrefs.SetString("last_winner", "-");
                SceneManager.LoadScene("End");
            }
        }
        else
        {
            GetComponent<AudioSource>().clip = wrong;
            GetComponent<AudioSource>().Play();
        }
    }

    bool checkWinner()
    {
        foreach (var combo in winningCombos)
        {
            if (boardState[combo[0]] != 0 &&
            boardState[combo[0]] == boardState[combo[1]] &&
            boardState[combo[1]] == boardState[combo[2]])
            {
                return true;
            }
        }
        return false;
    }
}
