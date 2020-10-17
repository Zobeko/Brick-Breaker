using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerAvatar playerAvatar = null;
    private AbstractBall abstractBall = null;

    private void Start()
    {
        playerAvatar = this.GetComponent<PlayerAvatar>();
        abstractBall = playerAvatar.currentBall.GetComponent<AbstractBall>();
    }

    private void Update()
    {
        //Gere les inputs de déplacements horizontaux
        HorizontalMovements();

        //Gere le lancement de la balle depis la raquette
        BallLauncher();
    }

    private void HorizontalMovements()
    {
        float HorizMvt = Input.GetAxis("Horizontal");
        playerAvatar.Speed = new Vector2(HorizMvt, 0) * playerAvatar.SpeedMax ;
    }

    private void BallLauncher()
    {
        if (Input.GetButtonDown("Launch") && !abstractBall.ballIsLaunched)
        {
            abstractBall.ballIsLaunched = true;
        }
    }
}
