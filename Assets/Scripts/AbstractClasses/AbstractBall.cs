using UnityEngine;

public abstract class AbstractBall : MonoBehaviour
{
    //On utilise tempSpeed afin de récuperer une vitesse dans l'update et d'ensuite l'appliquer au RigidBody dans FixedUpdate()
    protected Vector2 tempSpeed = Vector2.zero;
    public Vector2 Speed
    {
        get { return this.GetComponent<Rigidbody2D>().velocity; }
        set { this.GetComponent<Rigidbody2D>().velocity = value; }
    }

    public Vector2 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public bool ballIsLaunched = false;
    
    [SerializeField] private GameObject player = null;
    [SerializeField] private Rigidbody2D playerRigidBody = null;
    [SerializeField] private Rigidbody2D rigidBody = null;
    public float initialBallSpeed = 0f;
    public float damages = 0;
    [SerializeField] protected int launchCpt = 0;



    private void Awake()
    {
        player = GameManager.instance.playerInstance;
        ballIsLaunched = false;
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        rigidBody = this.GetComponent<Rigidbody2D>();

    }

   
    

    protected void KeepBallOnRacket()
    {
        if (!ballIsLaunched)
        {
            //Tant que la balle n'est pas lancée, elle reste collée au centre de la raquette
            rigidBody.position = new Vector2(playerRigidBody.position.x, (player.transform.position.y + player.transform.lossyScale.y/2 + this.transform.lossyScale.y/1.25f));
            
        
        }
       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        

        if (col.transform.CompareTag("Player"))
        {
            if (Speed.x <= 0)
            {
                Speed = new Vector2(-initialBallSpeed, initialBallSpeed) * Time.deltaTime;
            }
            else
            {
                Speed = new Vector2(initialBallSpeed, initialBallSpeed) * Time.deltaTime;
            }
        }
    }




}
