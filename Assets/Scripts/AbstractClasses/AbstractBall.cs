using System.Collections;
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

    private bool ballIsLaunched = false;
    [SerializeField] private GameObject player = null;
    [SerializeField] private Rigidbody2D playerRigidBody = null;
    [SerializeField] private Rigidbody2D rigidBody = null;

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

            rigidBody.position = new Vector2(playerRigidBody.position.x, (player.transform.position.y + player.transform.lossyScale.y/2 + this.transform.lossyScale.y/1.25f));
            //rigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0);
        
        }
    }




}
