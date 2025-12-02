using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;

    float xVelocity = 0.0f;
    float zVelocity = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;


    public void SetTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

    public void UpdateMovementAnimation(bool isMoving, bool isGrounded, bool isSprinting)//, bool isJumping)
    {
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsSprinting", isSprinting);
        animator.SetBool("IsMoving", isMoving);

        //animator.SetBool("IsJumping", isJumping);
    }

    public void UpdateDirectionAnimation(float xMovement, float zMovement, bool isSprinting)
    {
        bool forwardPressed = zMovement > 0.05;
        bool backwardPressed = zMovement < -0.05;
        bool rightPressed = xMovement > 0.05;
        bool leftPressed = xMovement < -0.05;


        // Forward Velocity
        if (forwardPressed && zVelocity < 1.0f)
        {
            zVelocity += Time.deltaTime * acceleration;
        } 
        // Backwards Velocity
        if (backwardPressed && zVelocity > -1.0f)
        {
            zVelocity -= Time.deltaTime * acceleration;
        } 
        // Right Velocity
        if (rightPressed && xVelocity < 1.0f)
        {
            xVelocity += Time.deltaTime * acceleration;
        } 
        // Left Velocity
        if (leftPressed && xVelocity > -1.0f)
        {
            xVelocity -= Time.deltaTime * acceleration;
        } 

        // Forward Deceleration
        if (!forwardPressed && zVelocity > 0.0f)
        {
            zVelocity -= Time.deltaTime * deceleration;
        }

        // Backward Deceleration
        if (!backwardPressed && zVelocity < 0.0f)
        {
            zVelocity += Time.deltaTime * deceleration;
        }

        // Right Deceleration
        if (!rightPressed && xVelocity > 0.0f)
        {
            xVelocity -= Time.deltaTime * deceleration;
        }

        // Left Deceleration
        if (!leftPressed && xVelocity < 0.0f)
        {
            xVelocity += Time.deltaTime * deceleration;
        }

        // X Velocity Reset
        if (!leftPressed && !rightPressed && xVelocity != 0.0f && (xVelocity > -0.05f && xVelocity < 0.05f))
        {
            xVelocity = 0.0f;
        }

        // Z Velocity Reset
        if (!forwardPressed && !backwardPressed && zVelocity != 0.0f && (zVelocity < 0.05f && zVelocity > 0.05f))
        {
            zVelocity = 0.0f;
        }

        // Set Animator Parameters
        animator.SetFloat("xVelocity", xVelocity);
        animator.SetFloat("zVelocity", zVelocity);
    }

    //public void PlayFallingLoop()
    //{
    //    animator.SetTrigger("FallingLoop");
    //}

    //public void PlayJumpWhileRunning()
    //{
    //    animator.SetTrigger("JumpWhileRunning");
    //}
}
