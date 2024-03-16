using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public LifeController selfLifeController;
    public Text lifeText;
    // Start is called before the first frame update
    void Start()
    {
        selfLifeController = GetComponentInParent<LifeController>();
        lifeText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = selfLifeController.GetLife().ToString();
        if (selfLifeController.GetLife()<40)
        {
            lifeText.color = Color.red;
        }
        else{
            lifeText.color = Color.black;
        }
    }
}
