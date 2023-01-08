using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnerController : MonoBehaviour
{
    [SerializeField] float spawnGapTime = 20;
    [SerializeField] float spawnGapDeltaTime = 0.1f;
    [SerializeField] GameObject meteorAlert = null;
    [SerializeField] GameObject meteor = null;
    [SerializeField] GameObject meteorBoom = null;
    float timer = 0;
    Vector2 meteorPosition;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnGapTime)
        {
            int x = Random.Range(-16, 17);
            int y = Random.Range(-10, 11);
            meteorPosition = new Vector2(x, y);
            Instantiate(meteorAlert, meteorPosition, Quaternion.identity);
            Instantiate(meteor, meteorPosition, Quaternion.identity);
            Invoke("MeteorBoom", 2);
            if (spawnGapTime > 0)
            {
                spawnGapTime -= spawnGapDeltaTime;
            }
            timer = 0;
        }
    }
    void MeteorBoom()
    {
        Instantiate(meteorBoom, meteorPosition, Quaternion.identity);
    }
}
