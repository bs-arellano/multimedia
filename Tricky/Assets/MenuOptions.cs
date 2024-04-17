using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    public void Jugar(){
        SceneManager.LoadScene("Board");
    }
    public void Salir(){
        if (UnityEditor.EditorApplication.isPlaying){
            UnityEditor.EditorApplication.isPlaying =false;
        } else{
            Application.Quit();
        }
    }
}
