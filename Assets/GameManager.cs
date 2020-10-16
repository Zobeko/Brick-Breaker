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

        Instantiate(ballPrefab);
    }
}
