using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public enum PlayerStates { Run, Jump, Fall, Dash, Dead};
    public PlayerStates state;

    public static Action OnPerformRun;
    public static Action OnPerformJump;
    public static Action OnPerformFall;
    public static Action OnPerformDash;

    private void Start()
    {
        SetRun();
    }
    private void OnEnable()
    {
        PlayerCollisions.OnGrounded += PerformGrounded;
        PlayerJump.OnFalling += PerformFalling;
    }

    private void OnDisable()
    {
        PlayerCollisions.OnGrounded -= PerformGrounded;
        PlayerJump.OnFalling -= PerformFalling;
    }

    public void OnJump() => CheckNewState(PlayerStates.Jump);

    public void OnDash() => CheckNewState(PlayerStates.Dash);

    void CheckNewState(PlayerStates newState)
    {
        if (newState == PlayerStates.Dead)
            state = newState;

        if (state == PlayerStates.Run)
        {
            if (newState == PlayerStates.Jump)
            {
                state = newState;
                OnPerformJump?.Invoke();
            }
                
            else if (newState == PlayerStates.Dash)
            {
                state = newState;
                OnPerformDash?.Invoke();
            }    
        }
    }

    void PerformGrounded()
    {
        SetRun();
    }

    void PerformFalling()
    {
        SetFalling();
    }

    public void PerformDashEnd()
    {
        SetRun();
    }

    void SetRun()
    {
        if (state == PlayerStates.Dead)
            return;

        state = PlayerStates.Run;
        OnPerformRun?.Invoke();
    }

    void SetFalling()
    {
        if (state == PlayerStates.Dead)
            return;

        state = PlayerStates.Fall;
        OnPerformFall?.Invoke();
    }
}
