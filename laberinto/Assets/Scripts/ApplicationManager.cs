using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public void CloseGame()
    {
        Debug.Log("Closing game from main menu");
        if (UnityEditor.EditorApplication.isPlaying) {
            UnityEditor.EditorApplication.isPlaying = false;
        } else {
            Application.Quit(0);
        }
    }
}
