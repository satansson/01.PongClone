using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxExtraSpeed;

    int hitCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    void BallPosition(bool isPlayer1Statring)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isPlayer1Statring)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isPlayer1Starting = true)
    {
        this.BallPosition(isPlayer1Starting);

        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isPlayer1Starting)
            this.MoveBall(new Vector2(-1, 0));
        else
            this.MoveBall(new Vector2(1, 0));
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;

        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        //rigidbody2D.velocity = dir * speed * Time.deltaTime;
        rigidbody2D.velocity = dir * speed;
    }

    public void IncreaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
            this.hitCounter++;
    }
}
