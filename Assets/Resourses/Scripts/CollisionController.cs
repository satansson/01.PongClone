using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreController scoreController;

    void BounceFromRacket(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 racketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y;

        float x;
        if (c.gameObject.name == "Player1Racket")
            x = 1;
        else
            x = -1;

        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1Racket" || collision.gameObject.name == "Player2Racket")
            this.BounceFromRacket(collision);
        else if (collision.gameObject.name == "LeftWall")
        {
            Debug.Log("Collision with Left Wall");
            this.scoreController.Player2Goal();
            StartCoroutine(this.ballMovement.StartBall(true));
        }
            
        else if (collision.gameObject.name == "RightWall")
        {
            Debug.Log("Collision with Right Wall");
            this.scoreController.Player1Goal();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
            
    }
}
