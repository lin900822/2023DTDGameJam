using System.Collections;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public int PlayerID = 0;

    public int Hp = 10;

    public InputHandler inputHandler;

    public GameObject bullet;

    [SerializeField] float playerspeed = 10f;

    Vector2 move;

    Rigidbody2D myrigidbody;

    [SerializeField] float firecd = 0.5f;

    [SerializeField] private ParticleSystem hitEffect = null;
    
    float timer = 0;

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
        Vector2 moveinput = inputHandler.GetLeftStickAxis(PlayerID);
        move = new Vector2(moveinput.x, moveinput.y);
        Vector2 rotateinput = inputHandler.GetRightStickAxis(PlayerID);
        if (rotateinput != Vector2.zero)
        {
            transform.right = new Vector2(rotateinput.x, rotateinput.y);
        }
        timer += Time.deltaTime;
        if (inputHandler.GetFired(PlayerID) && timer >= firecd)
        {
            GameObject bulletClone = Instantiate(bullet, this.transform.position, transform.rotation);
            bulletClone.GetComponent<BulletCon>().OwnerID = PlayerID;
            timer = 0;
        }
        myrigidbody.velocity = move * playerspeed;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<BulletCon>(out var bulletCon))
        {
            if (bulletCon.OwnerID == PlayerID) return;
            
            Hp--;
            Instantiate(hitEffect, transform.position, quaternion.identity);
            
        }
    }
}
