using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollisions : MonoBehaviour
{
    public static Action OnGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            OnGrounded?.Invoke();
    }
}
