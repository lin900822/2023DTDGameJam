using System.Collections;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public int PlayerID = 0;

    public int Hp = 10;

    public bool isOP = false;

    public InputHandler inputHandler;

    public GameObject bullet;

    [SerializeField] float playerspeed = 10f;

    Vector2 move;

    Rigidbody2D myrigidbody;

    [SerializeField] float firecd = 0.5f;

    [SerializeField] float skillcd = 8f;

    [SerializeField] float skillduration = 3f;

    [SerializeField] private ParticleSystem hitEffect = null;
    [SerializeField] private ParticleSystem deathEffect = null;

    [SerializeField] private Transform weaponTrans = null;

    float firetimer = 0;
    float skilltimer = 8f;
    float isOPtimer = 0;
    void Start()
    {
        //skilltimer = 8f;
        myrigidbody = GetComponent<Rigidbody2D>();
        isOPtimer = skillduration;
    }
    void Update()
    {
        if (Hp <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.Euler(180, 0, 0));
            Destroy(gameObject);
        }
        Vector2 moveinput = inputHandler.GetLeftStickAxis(PlayerID);
        move = new Vector2(moveinput.x, moveinput.y);
        Vector2 rotateinput = inputHandler.GetRightStickAxis(PlayerID);
        if (rotateinput != Vector2.zero)
        {
            //transform.right = new Vector2(rotateinput.x, rotateinput.y);
        }

        firetimer += Time.deltaTime;
        skilltimer += Time.deltaTime;
        isOPtimer += Time.deltaTime;

        if (inputHandler.GetSkilled(PlayerID) && skilltimer >= skillcd)
        {
            isOP = true;
            Debug.Log("skillTriggered");
            GetComponent<PlayerAlphaController>().SetHightlighted(1f, skillduration);
            skilltimer = 0;
            isOPtimer = 0;
            firetimer = firecd - skillduration;
        }
        if(isOP == true && isOPtimer >= skillduration){
            isOP = false;
        }
        if (inputHandler.GetFired(PlayerID) && firetimer >= firecd)
        {
            GameObject bulletClone = Instantiate(bullet, weaponTrans.position, weaponTrans.rotation);
            bulletClone.GetComponent<BulletCon>().OwnerID = PlayerID;
            firetimer = 0;
        }
        myrigidbody.velocity = move * playerspeed;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<BulletCon>(out var bulletCon))
        {
            if (bulletCon.OwnerID == PlayerID) return;

            if(isOP == false){
                Hp--;
            }

            Instantiate(hitEffect, transform.position, quaternion.identity);

        }
    }


}