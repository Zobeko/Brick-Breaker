using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    

    public void ResumeButton()
    {
        UIManager.instance.pauseMenuON = false;
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        Cursor.visible = false;
        this.gameObject.SetActive(false);
    }

    public void RetryButton()
    {
        UIManager.instance.pauseMenuON = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    
}
