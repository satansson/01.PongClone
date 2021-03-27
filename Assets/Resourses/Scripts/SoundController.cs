using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1Racket" || collision.gameObject.name == "Player2Racket")
            this.racketSound.Play();
        else
            this.wallSound.Play();
    }

}
