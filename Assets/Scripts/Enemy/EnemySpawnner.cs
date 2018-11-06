using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject[] enemylist;
    [Space]
    public float spawnrate;
    Vector2 wheretospawn;
    float randY;
    float nextspawn;

    public float RandRange1 = 4;
    public float RandRange2 = -4;

    void Update()
    {
        if (Time.timeSinceLevelLoad > 3)
        {
            if (Time.time > nextspawn)
            {
                nextspawn = Time.time + spawnrate;
                randY = Random.Range(RandRange1, RandRange2);
                wheretospawn = new Vector2(transform.position.x, randY);
                Instantiate(enemylist[Random.Range(0, enemylist.Length)], wheretospawn, Quaternion.identity);
            }
        }

    }
}
