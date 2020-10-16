using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerAvatar playerAvatar = null;

    private void Awake()
    {
        playerAvatar = this.GetComponent<PlayerAvatar>();
    }

    private void Update()
    {
        //Gere les inputs de déplacements horizontaux
        HorizontalMovements();
    
    }

    private void HorizontalMovements()
    {
        float HorizMvt = Input.GetAxis("Horizontal");
        playerAvatar.Speed = new Vector2(HorizMvt, 0) * playerAvatar.SpeedMax ;
    }
}
