using UnityEngine;

public class BrickAvatar : AbstractAvatar
{
    [SerializeField] private int numberOfRaycastByWidth = 0;
    [SerializeField] private int numberOfRaycastByHeight = 0;
    protected float raycastsDistanceWidth = 0;
    protected float raycastsDistanceheight = 0;
    [SerializeField] private LayerMask ballLayerMask;
    [SerializeField] protected GameObject gameManager = null;
    
    protected SpriteRenderer spriteRenderer = null;
    public float width = 0f;
    public float height = 0f;
    [SerializeField]private PlayerAvatar playerAvatar;

    //Enum qui contient les differents types de briques
    public enum BrickType { simpleBrick };
    public BrickType brickType;



    void Start()
    {
        
        playerAvatar = GameManager.instance.playerInstanceAvatar;
    }



    protected void RaycastCollisions()
    {
        //Gere toutes les collisions sur les briques
        AbstractBall currentBallAvatar = playerAvatar.currentBall.GetComponent<SimpleBall>();


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

    protected void Die()
    {
        if(currentHealth <= 0)
        {
            BricksFactory.ReleaseBrick(this);
        }
    }
    


    


}
