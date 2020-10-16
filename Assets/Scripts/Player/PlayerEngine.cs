using UnityEngine;

public class PlayerEngine : MonoBehaviour
{
    private PlayerAvatar playerAvatar;
    
    private void Awake()
    {
        playerAvatar = this.GetComponent<PlayerAvatar>();
        
    }

    private void FixedUpdate()
    {
        //Gere les movements du player (qui sont uniquement horizontaux)
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerAvatar.RigidBody.velocity = playerAvatar.Speed * Time.deltaTime;
    }
}
