using UnityEngine;

public class PlayerAvatar : AbstractAvatar
{


    //Speed
    [SerializeField]private Vector2 speed = Vector2.zero;
    public Vector2 Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    //SpeedMax
    [SerializeField] private float speedMax = 0;
    public float SpeedMax
    {
        get { return speedMax; }
        set { speedMax = value; }
    }
    
    public GameObject[] balls = new GameObject[3];
    public GameObject currentBall = null;
    public int currentBallIndex = 0;
    [SerializeField] protected int numberOfAvailableBalls = 0;

    private void Awake()
    {
        RigidBody = this.GetComponent<Rigidbody2D>();
        currentHealth = healthMax;
        numberOfAvailableBalls = balls.Length - currentBallIndex;
    }

    void Start()
    {
        currentBallIndex = 0;
        currentBall = balls[currentBallIndex];

        currentBall.SetActive(true);
    }


    void Update()
    {
        
    }
}
