using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] float lifeTime = 5;
    [SerializeField] float meteorFallTime = 2;
    [SerializeField] float meteorCrashTime = 3;
    void Start()
    {
        Destroy(gameObject, lifeTime);
        Invoke("MeteorFall", meteorFallTime);
        Invoke("MetoerCrash", meteorCrashTime);
    }
    void MeteorFall()
    {
        CircleCollider2D meteorCollider = gameObject.AddComponent<CircleCollider2D>();
        meteorCollider.isTrigger = true;
        meteorCollider.radius = 1.5f;

        StartCoroutine(CameraShake.Instance.Shake(.2f, .25f));
    }

    void MetoerCrash()
    {
        Destroy(GetComponent<CircleCollider2D>());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<characterMovement>(out var characterMovement))
        {
            characterMovement.Hp -= 2;
        }
    }
}
