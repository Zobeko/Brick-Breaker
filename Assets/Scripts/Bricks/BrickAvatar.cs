using UnityEngine;

public class BrickAvatar : AbstractAvatar
{
    [SerializeField] private int numberOfRaycastByWidth = 0;
    [SerializeField] private int numberOfRaycastByHeight = 0;
    private float raycastsDistanceWidth = 0;
    private float raycastsDistanceheight = 0;
    [SerializeField] private LayerMask ballLayerMask;
    [SerializeField] private GameObject gameManager = null;
    
    private SpriteRenderer spriteRenderer = null;
    private float width = 0f;
    private float height = 0f;
    private PlayerAvatar playerAvatar= null;



    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        width = spriteRenderer.bounds.size.x;
        height = spriteRenderer.bounds.size.y;

        raycastsDistanceWidth = (height / 2) + 0.2f;
        raycastsDistanceheight = (width / 2) + 0.2f;

        Debug.Log(width);
        Debug.Log(height);

    }

    private void Start()
    {
        playerAvatar = gameManager.GetComponent<GameManager>().playerInstance.GetComponent<PlayerAvatar>();
    }

    private void FixedUpdate()
    {
        RaycastCollisions();
    }

    private void Update()
    {
        

        Die();
    }

    private void RaycastCollisions()
    {
        //Gere toutes les collisions sur les briques

        AbstractBall currentBallAvatar = playerAvatar.currentBall.GetComponent<AbstractBall>();


        //Colisions face haute
        for (int i = 0; i < numberOfRaycastByWidth; i++)
        {

            Vector2 raycastPosition = new Vector2(this.transform.position.x - (width / 2) + (i + 1) * (width / numberOfRaycastByWidth), this.transform.position.y);
            //Debug.DrawRay(raycastPosition, Vector2.up * Mathf.Infinity, Color.red, Mathf.Infinity);

            if (Physics2D.Raycast(raycastPosition, Vector2.up, raycastsDistanceWidth, ballLayerMask))
            {
                if (currentBallAvatar.Speed.x < 0)
                {
                    currentBallAvatar.Speed = new Vector2(-currentBallAvatar.initialBallSpeed, currentBallAvatar.initialBallSpeed) * Time.deltaTime;
                }
                else if (currentBallAvatar.Speed.x >= 0)
                {
                    currentBallAvatar.Speed = new Vector2(currentBallAvatar.initialBallSpeed, currentBallAvatar.initialBallSpeed) * Time.deltaTime;
                }

                

                currentHealth -= currentBallAvatar.damages;

            }
        }

        //Colisions face basse
        for (int i = 0; i < numberOfRaycastByWidth; i++)
        {

            Vector2 raycastPosition = new Vector2(this.transform.position.x - (width / 2) + (i + 1) * (width / numberOfRaycastByWidth), this.transform.position.y);


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

                currentHealth -= currentBallAvatar.damages;

            }
        }

        //Colisions face gauche
        for (int i = 0; i < numberOfRaycastByHeight; i++)
        {

            Vector2 raycastPosition = new Vector2(this.transform.position.x, this.transform.position.y - (height / 2) + (i + 1) * (height / numberOfRaycastByHeight));


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

                currentHealth -= currentBallAvatar.damages;

            }
        }

        //Colisions face droite
        for (int i = 0; i < numberOfRaycastByHeight; i++)
        {

            Vector2 raycastPosition = new Vector2(this.transform.position.x, this.transform.position.y - (height / 2) + (i + 1) * (height / numberOfRaycastByHeight));


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

                currentHealth -= currentBallAvatar.damages;
            }
        }

    }
    


    


}
