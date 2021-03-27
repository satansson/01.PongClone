﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Racket : MonoBehaviour
{
    public float movementSpeed;

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }
}
