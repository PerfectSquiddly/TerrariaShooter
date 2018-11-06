using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletronprimeMovement : AirBomberEnemy
{

    public GameObject spinaround;
    public GameObject[] skeletronlaser;


    void Start()
    {
        scorescript = GameObject.Find("Score").GetComponent<Score>();

        Instantiate(skeletronlaser[0], new Vector3(0.2f,0,0), Quaternion.identity);
        Instantiate(skeletronlaser[1], new Vector3(-0.2f,0,0), Quaternion.identity);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RotateAround();
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);

        randomX = Random.Range(0, 360);

        randomY = Random.Range(0, 360);

        randomZ = Random.Range(0, 360);
        var randomDir = new Vector3(randomX, randomY, randomZ);
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;

            GameObject randombullet = Instantiate(enemybullet, transform.position, Quaternion.identity);
            if (Random.value < 0.5f)
            {
                randombullet.GetComponent<Rigidbody2D>().velocity = randomDir * -bulletspeed * Time.deltaTime;
            }
            else
            {
                randombullet.GetComponent<Rigidbody2D>().velocity = randomDir * bulletspeed * Time.deltaTime;
            }

        }
    }
    void RotateAround()
    {
        transform.RotateAround(new Vector3(0,0,0), Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
    }
}
