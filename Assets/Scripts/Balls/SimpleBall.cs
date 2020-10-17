using UnityEngine;

public class SimpleBall : AbstractBall
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        KeepBallOnRacket();

        if (ballIsLaunched && launchCpt == 0)
        {
            launchCpt++;
            //Lance la balle en direction diagonale vers la droite
            Speed = new Vector2(initialBallSpeed, initialBallSpeed) * Time.deltaTime;
        }
    }
}
