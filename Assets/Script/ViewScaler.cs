using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViewScaler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;

    [SerializeField] private List<Transform> targets = null;

    [SerializeField] private Vector2 viewRange = Vector2.zero;
    [SerializeField] private float maxDistance = 100f;
    
    private void LateUpdate()
    {
        SetView();
    }

    private void SetView()
    {
        float t = GetMaxDistanceBetweenPlayer() / maxDistance;

        mainCamera.orthographicSize = Mathf.Lerp(viewRange.x, viewRange.y, t);
    }

    private float GetMaxDistanceBetweenPlayer()
    {
        float maxDistance = 0f;
        
        for (int i = 0; i < targets.Count; i++)
        {
            for (int j = 0; j < targets.Count; j++)
            {
                if (i != j)
                {
                    float deltaX = (targets[i].position.x - targets[j].position.x);
                    float deltaY = (targets[i].position.y - targets[j].position.y);

                    float dis = deltaX * deltaX + deltaY * deltaY;

                    if (dis > maxDistance)
                    {
                        maxDistance = dis;
                    }
                }
            }
        }

        return Mathf.Sqrt(maxDistance);
    }

    private Vector2 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (var i = 0; i < targets.Count; i++)
        {
            var t = targets[i];
            bounds.Encapsulate(t.position);
        }

        return bounds.center;
    }
}
