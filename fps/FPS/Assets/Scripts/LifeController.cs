using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int life;
    void Start()
    {
        life = 100;
    }

    public void ReduceLife(int damage)
    {
        life -= damage;
    }
    public void ResetLife(){
        life = 100;
    }
    public int GetLife()
    {
        return life;
    }
}
