using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private characterMovement player = null;
    
    [SerializeField] private InputHandler inputHandler = null;

    [SerializeField] private SpriteRenderer spriteRenderer = null;

    [SerializeField] private Animator animator = null;

    [SerializeField] private Transform weapon = null;

    private bool lastFilpX = false;
    
    private void Update()
    {
        Vector2 moveInput = inputHandler.GetLeftStickAxis(player.PlayerID);
        Vector2 rotationInput = inputHandler.GetRightStickAxis(player.PlayerID);
        
        
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("isWalking", true);

            spriteRenderer.flipX = !(moveInput.x >= 0);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (rotationInput != Vector2.zero)
        {
            weapon.right = rotationInput;
        }

        if (lastFilpX != spriteRenderer.flipX)
        {
            if (spriteRenderer.flipX)
            {
                weapon.right = new Vector2(-Mathf.Abs(weapon.right.x), weapon.right.y);
            }
            else
            {
                weapon.right = new Vector2(Mathf.Abs(weapon.right.x), weapon.right.y);
            }
        }
        
        lastFilpX = spriteRenderer.flipX;
    }
}
