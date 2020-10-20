using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject ballPrefab = null;
    [SerializeField] private GameObject simpleBrickPrefab = null;
    [SerializeField] private int numberOfBricksByLine = 0;
    [SerializeField] private int numberOfBricksByColumn = 0;

    private float brickWidth = 0f;
    private float brickHeight = 0f;

    public GameObject playerInstance = null;
    public PlayerAvatar playerInstanceAvatar = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        Instanciation();
    }

    void Start()
    {
        brickWidth = simpleBrickPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        brickHeight = simpleBrickPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        BricksInstantiation();
    
    }


    private void Instanciation()
    {
        //Player instantiation
        playerInstance = Instantiate(playerPrefab);
        playerInstanceAvatar = playerInstance.GetComponent<PlayerAvatar>();

        //Balls instantiation
        for (int i = 0; i < 3; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.SetActive(false);
            playerInstance.GetComponent<PlayerAvatar>().balls[i] = ball;
        }

        

        
    }

    private void BricksInstantiation()
    {
        //SimpleBricks instantiation
        for (int i = 0; i < numberOfBricksByLine; i++)
        {
            float brickPosX = simpleBrickPrefab.transform.position.x + (i * brickWidth);

            for (int j = 0; j < numberOfBricksByColumn; j++)
            {
                float brickPosY = simpleBrickPrefab.transform.position.y - (j * brickHeight);

                GameObject brick = BricksFactory.GetBrick(BrickAvatar.BrickType.simpleBrick).gameObject;
                brick.transform.position = new Vector2(brickPosX, brickPosY);

            }

        }
    }
}
