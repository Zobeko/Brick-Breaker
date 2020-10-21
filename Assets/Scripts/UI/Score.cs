using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreCpt = 0;
    private Text scoreText = null;

    public static Score instance;

    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        scoreText = this.GetComponent<Text>();
    }


    void Update()
    {
        scoreText.text = "Score : " + scoreCpt;
    }
}
