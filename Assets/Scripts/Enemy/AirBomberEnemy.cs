using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBomberEnemy : ShootingEnemy
{
    public float bulletspeed;
    public float randomX;
    public float randomY;
    public float randomZ;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Canshoot == false)
        {
            CanshootFalseMove();
        }
        if (Canshoot == true)
        {
            movetoleft();
            randomX = Random.Range(0, 360);

            randomY = Random.Range(0, 360);

            randomZ = Random.Range(0, 360);
            var randomDir = new Vector3(randomX, randomY, randomZ);
            if (Time.time > nextfire)
            {
                nextfire = Time.time + firerate;

                GameObject randombullet = Instantiate(enemybullet, transform.position, Quaternion.identity);
                randombullet.GetComponent<Rigidbody2D>().velocity = randomDir * -bulletspeed * Time.deltaTime;

            }
        }
    }
}
