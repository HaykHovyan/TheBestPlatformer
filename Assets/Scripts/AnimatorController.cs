using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerController.horizontalMove != 0 && PlayerController.isGrounded)
        {
            animator.SetBool("isWalking", true);
        }

        else
        { 
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.W) && PlayerController.isGrounded)
        {
            animator.SetBool("isJumping", true);
        }

        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
