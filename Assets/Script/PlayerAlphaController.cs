using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlphaController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite = null;
    [SerializeField] private SpriteRenderer weaponSprite = null;

    [SerializeField] private float detectRadius = 5f;

    [SerializeField] private LayerMask lightLayerMask = default;
    
    private Collider2D[] lights = new Collider2D[10];

    private void Update()
    {
        GetLights();
        SetAlpha(1f - GetMinDistanceBetweenLight() / detectRadius);
    }

    private float GetMinDistanceBetweenLight()
    {
        float minDis = 999f;
        
        foreach (var light in lights)
        {
            if(light == null) continue;
            
            float deltaX = transform.position.x - light.transform.position.x;
            float deltaY = transform.position.y - light.transform.position.y;
            float dis = deltaX * deltaX + deltaY * deltaY;

            if (dis < minDis)
            {
                minDis = dis;
            }
        }

        return minDis;
    }
    
    private void GetLights()
    {
        for (var i = 0; i < lights.Length; i++)
        {
            var l = lights[i];
            l = null;
        }

        Physics2D.OverlapCircleNonAlloc(transform.position, detectRadius, lights, lightLayerMask);
    }

    private void SetAlpha(float alpha)
    {
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, alpha);
        weaponSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, alpha);
    }
}
