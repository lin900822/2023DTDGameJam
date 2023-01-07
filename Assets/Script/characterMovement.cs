using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public int PlayerID = 0; 
    
    public InputHandler inputHandler;
    
    public GameObject bullet;
    private Vector2 move;
    
    [SerializeField]
    float playerspeed = 10f;

    Rigidbody2D myrigidbody;
    
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 moveinput = inputHandler.GetLeftStickAxis(PlayerID);
        move = new Vector2(moveinput.x, moveinput.y);
        Vector2 rotateinput = inputHandler.GetRightStickAxis(PlayerID);

        transform.right = new Vector2(rotateinput.x, rotateinput.y);

        if (inputHandler.GetFired(PlayerID))
        {
            GameObject bulletClone = Instantiate(bullet, this.transform.position + transform.right, transform.rotation);
        }
        myrigidbody.velocity = move * playerspeed;
    }
}
