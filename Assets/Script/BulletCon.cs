using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCon : MonoBehaviour
{
    public float G = 66700f;
    [SerializeField]
    float speed = 10f;

    [SerializeField] private float virtualZ = 225f;
    
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, 1);
    }
    
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "gravity")
        {
            this.GetComponent<Rigidbody2D>().AddForce(G / Mathf.Pow(GetRadius(this.transform.position, collider.transform.position), 2) * ((collider.transform.position - this.transform.position) / GetRadius(this.transform.position, collider.transform.position)));
        }
    }
    float GetRadius(Vector2 first, Vector2 second)
    {
        return (Mathf.Sqrt((first.x - second.x) * (first.x - second.x) + (first.y - second.y) * (first.y - second.y) + virtualZ));
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag!="gravity"){
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<Collider2D>());
        }
    }
}
