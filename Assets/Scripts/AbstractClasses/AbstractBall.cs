using UnityEngine;

public abstract class AbstractBall : MonoBehaviour
{
    [SerializeField] private Vector2 speed = Vector2.zero;
    public Vector2 Speed
    {
        get { return speed; }
        set { speed = value; }
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
            ballIsLaunched = value;
            if (ballIsLaunched)
            {
                //Lance la balle en direction diagonale vers la droite
                rigidBody.velocity = new Vector2(initialBallSpeed, initialBallSpeed) * Time.deltaTime;
            }


        }
    }
    [SerializeField] private GameObject player = null;
    [SerializeField] private Rigidbody2D playerRigidBody = null;
    [SerializeField] private Rigidbody2D rigidBody = null;
    [SerializeField] private float initialBallSpeed = 0f;



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
            if(rigidBody.velocity.x < 0)
            {
                rigidBody.velocity = new Vector2(-initialBallSpeed, -initialBallSpeed) * Time.deltaTime;
            }
            else
            {
                rigidBody.velocity = new Vector2(initialBallSpeed, -initialBallSpeed) * Time.deltaTime;
            }

            
        }
        else if (col.transform.CompareTag("Walls"))
        {

            if (rigidBody.velocity.x < 0)
            {
                if(rigidBody.velocity.y < 0)
                {
                    rigidBody.velocity = new Vector2(initialBallSpeed, -initialBallSpeed) * Time.deltaTime;
                }
                else
                {
                    rigidBody.velocity = new Vector2(initialBallSpeed, initialBallSpeed) * Time.deltaTime;
                }
                
            }
            else
            {
                if (rigidBody.velocity.y < 0)
                {
                    rigidBody.velocity = new Vector2(-initialBallSpeed, -initialBallSpeed) * Time.deltaTime;
                }
                else
                {
                    rigidBody.velocity = new Vector2(-initialBallSpeed, initialBallSpeed) * Time.deltaTime;
                }
            }
        }

        else if (col.transform.CompareTag("Player"))
        {
            if (rigidBody.velocity.x < 0)
            {
                rigidBody.velocity = new Vector2(-initialBallSpeed, initialBallSpeed) * Time.deltaTime;
            }
            else
            {
                rigidBody.velocity = new Vector2(initialBallSpeed, initialBallSpeed) * Time.deltaTime;
            }
        }
    }




}
