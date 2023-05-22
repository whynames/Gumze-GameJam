using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    public void MoveCharacter(Vector2 moveDirection, float movePower = 1)
    {
        rb.AddForce(moveDirection * movePower * Time.deltaTime * 200);
    }

    internal void MoveCharacter(object value)
    {
        throw new NotImplementedException();
    }
}
