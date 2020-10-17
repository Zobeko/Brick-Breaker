using UnityEngine;

public abstract class AbstractBall : MonoBehaviour
{
    
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

    [SerializeField] private bool ballIsLaunched = false;
    public bool BallIsLaunched
    {
        get { return ballIsLaunched;  }
        set
        {
            
            if (!ballIsLaunched)
            {
                //Lance la balle en direction diagonale vers la droite
                Speed = new Vector2(initialBallSpeed, initialBallSpeed) * Time.deltaTime;
            }
            ballIsLaunched = value;


        }
    }
    [SerializeField] private GameObject player = null;
    [SerializeField] private Rigidbody2D playerRigidBody = null;
    [SerializeField] private Rigidbody2D rigidBody = null;
    public float initialBallSpeed = 0f;
    public float damages = 0;



    private void Awake()
    {
        player = GameManager.instance.playerInstance;
        ballIsLaunched = false;
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        rigidBody = this.GetComponent<Rigidbody2D>();

    }


    

    protected void LaunchBall()
    {
        if (!ballIsLaunched)
        {
            //Tant que la balle n'est pas lancée, elle reste collée au centre de la raquette
            rigidBody.position = new Vector2(playerRigidBody.position.x, (player.transform.position.y + player.transform.lossyScale.y/2 + this.transform.lossyScale.y/1.25f));
            
        
        }
       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.transform.CompareTag("Roof"))
        {
            if(Speed.x < 0)
            {
                Speed = new Vector2(-initialBallSpeed, -initialBallSpeed) * Time.deltaTime;
            }
            else
            {
                Speed = new Vector2(initialBallSpeed, -initialBallSpeed) * Time.deltaTime;
            }

            
        }
        else if (col.transform.CompareTag("Walls"))
        {

            if (Speed.x < 0)
            {
                if(Speed.y < 0)
                {
                    Speed = new Vector2(initialBallSpeed, -initialBallSpeed) * Time.deltaTime;
                }
                else
                {
                    Speed = new Vector2(initialBallSpeed, initialBallSpeed) * Time.deltaTime;
                }
                
            }
            else
            {
                if (Speed.y < 0)
                {
                    Speed = new Vector2(-initialBallSpeed, -initialBallSpeed) * Time.deltaTime;
                }
                else
                {
                    Speed = new Vector2(-initialBallSpeed, initialBallSpeed) * Time.deltaTime;
                }
            }
        }

        else if (col.transform.CompareTag("Player"))
        {
            if (Speed.x < 0)
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
