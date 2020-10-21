using UnityEngine;

public class SimpleBrick : BrickAvatar
{

    private void Awake()
    {
        this.brickType = BrickType.simpleBrick;

        spriteRenderer = this.GetComponent<SpriteRenderer>();
        width = spriteRenderer.bounds.size.x;
        height = spriteRenderer.bounds.size.y;

        raycastsDistanceWidth = (height / 2) + 0.2f;
        raycastsDistanceheight = (width / 2) + 0.2f;


    }

    

    private void FixedUpdate()
    {
        RaycastCollisions();
    }

    private void Update()
    {


        Die();
    }
}
