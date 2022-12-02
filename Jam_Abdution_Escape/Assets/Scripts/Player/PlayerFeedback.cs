using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedback : MonoBehaviour
{
    Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerManager.OnPerformRun += AnimateRun;
        PlayerManager.OnPerformDash += AnimateDash;
        PlayerManager.OnPerformJump += AnimateJump;
        PlayerManager.OnPerformFall += AnimateFall;
    }

    private void OnDisable()
    {
        PlayerManager.OnPerformRun -= AnimateRun;
        PlayerManager.OnPerformDash -= AnimateDash;
        PlayerManager.OnPerformJump += AnimateJump;
        PlayerManager.OnPerformFall += AnimateFall;
    }

    private void AnimateRun()
    {
        if (playerAnimator == null)
            return;
        playerAnimator.SetBool("Dash", false);
        playerAnimator.SetBool("Jump", false);
        playerAnimator.SetBool("Fall", false);
        playerAnimator.SetBool("Run", true);
    }

    private void AnimateDash()
    {
        if (playerAnimator == null)
            return;
        playerAnimator.SetBool("Run", false);
        playerAnimator.SetBool("Dash", true);
    }

    private void AnimateJump()
    {
        if (playerAnimator == null)
            return;
        playerAnimator.SetBool("Run", false);
        playerAnimator.SetBool("Jump", true);
    }

    private void AnimateFall()
    {
        if (playerAnimator == null)
            return;
        playerAnimator.SetBool("Jump", false);
        playerAnimator.SetBool("Fall", true);
    }
}
