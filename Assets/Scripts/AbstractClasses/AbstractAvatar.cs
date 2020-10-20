using UnityEngine;

public abstract class AbstractAvatar : MonoBehaviour
{
    public float healthMax = 0;
    public float currentHealth = 0;
    

    //[SerializeField] private Vector2 position = Vector2.zero;
    public Vector2 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public Rigidbody2D RigidBody { get; set; } = null;

    

    protected void Die()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
