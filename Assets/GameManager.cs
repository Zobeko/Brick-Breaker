using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject ballPrefab = null;

    public GameObject playerInstance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        Instanciation();
    }



    private void Instanciation()
    {
        playerInstance = Instantiate(playerPrefab);

        for (int i = 0; i < 3; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.SetActive(false);
            playerInstance.GetComponent<PlayerAvatar>().balls[i] = ball;
        }
        
    }
}
