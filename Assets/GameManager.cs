using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private GameObject playerPrefab = null;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        PlayerInstanciation();
    }



    private void PlayerInstanciation()
    {
        Instantiate(playerPrefab);
    }
}
