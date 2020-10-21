using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel = null;
    public bool pauseMenuON = false;

    public static UIManager instance;
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

        pauseMenuON = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Gère affichage et fermeture du menu pause
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenuON)
        {
            pauseMenuPanel.SetActive(true);
            pauseMenuON = true;
            Time.timeScale = 0f;
            AudioListener.volume = 0f;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuON)
        {
            pauseMenuPanel.SetActive(false);
            pauseMenuON = false;
            Time.timeScale = 1f;
            AudioListener.volume = 1f;
            Cursor.visible = false;
        }


    }
}
