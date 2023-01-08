using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private characterMovement player = null;
    
    [SerializeField] private InputHandler inputHandler = null;

    [SerializeField] private SpriteRenderer playerSpriteRenderer = null;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer = null;

    [SerializeField] private Animator animator = null;

    [SerializeField] private Transform weapon = null;
    
    private void Update()
    {
        Vector2 moveInput = inputHandler.GetLeftStickAxis(player.PlayerID);
        Vector2 rotationInput = inputHandler.GetRightStickAxis(player.PlayerID);
        
        
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("isWalking", true);

            playerSpriteRenderer.flipX = !(moveInput.x >= 0);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (rotationInput != Vector2.zero)
        {
            weapon.right = rotationInput;
        }

        weaponSpriteRenderer.flipY = rotationInput.x < 0;
    }
}
