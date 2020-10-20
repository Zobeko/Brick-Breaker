using UnityEngine;

public class WallCollisions : MonoBehaviour
{
    [SerializeField] private int numberOfRaycasts = 0;
    [SerializeField] private string raycastsDirection = null;
    [SerializeField] private LayerMask ballLayerMask;
    [SerializeField] private GameObject gameManager = null;

    private SpriteRenderer spriteRenderer = null;
    private float width = 0f;
    private float height = 0f;
    private PlayerAvatar playerAvatar = null;
    private float raycastsDistanceWidth = 0;
    private float raycastsDistanceheight = 0;


    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        width = spriteRenderer.bounds.size.x;
        height = spriteRenderer.bounds.size.y;

        raycastsDistanceWidth = (height / 2) ;
        raycastsDistanceheight = (width / 2) ;

        

    }

    private void Start()
    {
        playerAvatar = gameManager.GetComponent<GameManager>().playerInstance.GetComponent<PlayerAvatar>();
    }

    void FixedUpdate()
    {
        RaycastCollisions();
    }

    private void RaycastCollisions()
    {
        //Gere toutes les collisions sur les murs

        AbstractBall currentBallAvatar = playerAvatar.currentBall.GetComponent<AbstractBall>();

        if (raycastsDirection == "down")
        {
            //Colisions face basse (Roof)
            for (int i = 0; i < numberOfRaycasts; i++)
            {

                Vector2 raycastPosition = new Vector2(this.transform.position.x - (width / 2) + (i + 1) * (width / numberOfRaycasts), this.transform.position.y);
                //Debug.DrawRay(raycastPosition, Vector2.up * Mathf.Infinity, Color.red, Mathf.Infinity);

                if (Physics2D.Raycast(raycastPosition, Vector2.down, raycastsDistanceWidth, ballLayerMask))
                {
                    if (currentBallAvatar.Speed.x < 0)
                    {
                        currentBallAvatar.Speed = new Vector2(-currentBallAvatar.initialBallSpeed, -currentBallAvatar.initialBallSpeed) * Time.deltaTime;
                    }
                    else if (currentBallAvatar.Speed.x >= 0)
                    {
                        currentBallAvatar.Speed = new Vector2(currentBallAvatar.initialBallSpeed, -currentBallAvatar.initialBallSpeed) * Time.deltaTime;
                    }
                }
            }
        }


        //Colisions face gauche (RightWall)
        if (raycastsDirection == "left")
        {
            for (int i = 0; i < numberOfRaycasts; i++)
            {

                Vector2 raycastPosition = new Vector2(this.transform.position.x, this.transform.position.y - (height / 2) + (i + 1) * (height / numberOfRaycasts));


                if (Physics2D.Raycast(raycastPosition, Vector2.left, raycastsDistanceheight, ballLayerMask))
                {
                    if (currentBallAvatar.Speed.y < 0)
                    {
                        currentBallAvatar.Speed = new Vector2(-currentBallAvatar.initialBallSpeed, -currentBallAvatar.initialBallSpeed) * Time.deltaTime;
                    }
                    else if (currentBallAvatar.Speed.y >= 0)
                    {
                        currentBallAvatar.Speed = new Vector2(-currentBallAvatar.initialBallSpeed, currentBallAvatar.initialBallSpeed) * Time.deltaTime;
                    }

                }
            }
        }

        //Colisions face droite (LeftWall)
        if (raycastsDirection == "right")
        {
            for (int i = 0; i < numberOfRaycasts; i++)
            {

                Vector2 raycastPosition = new Vector2(this.transform.position.x, this.transform.position.y - (height / 2) + (i + 1) * (height / numberOfRaycasts));


                if (Physics2D.Raycast(raycastPosition, Vector2.right, raycastsDistanceheight, ballLayerMask))
                {
                    if (currentBallAvatar.Speed.y < 0)
                    {
                        currentBallAvatar.Speed = new Vector2(currentBallAvatar.initialBallSpeed, -currentBallAvatar.initialBallSpeed) * Time.deltaTime;
                    }
                    else if (currentBallAvatar.Speed.y >= 0)
                    {
                        currentBallAvatar.Speed = new Vector2(currentBallAvatar.initialBallSpeed, currentBallAvatar.initialBallSpeed) * Time.deltaTime;
                    }

                }
            }
        }

    }
}
