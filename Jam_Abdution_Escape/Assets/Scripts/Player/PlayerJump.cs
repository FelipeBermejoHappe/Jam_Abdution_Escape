using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;

    public static Action OnFalling;

    private Rigidbody2D myRigidbody;
    private bool checkFall;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();   
    }

    private void OnEnable()
    {
        PlayerManager.OnPerformJump += DoJump;
    }

    private void OnDisable()
    {
        PlayerManager.OnPerformJump -= DoJump;
    }

    void DoJump()
    {
        myRigidbody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
        checkFall = true;
    }

    private void FixedUpdate()
    {
        if (checkFall && myRigidbody.velocity.y < 0)
        {
            checkFall = false;
            OnFalling?.Invoke();
        }
    }
}
