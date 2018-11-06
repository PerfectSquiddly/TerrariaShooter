using UnityEngine;
using System.Collections;

public class EnemyMoveUpDown : MonoBehaviour
{


    int direction = 1; //int direction where 0 is stay, 1 up, -1 down    
    int top = 3;
    int bottom = -3;

    float speed = 5;


    void Update()
    {
        if (transform.position.y >= top)
            direction = -1;

        if (transform.position.y <= bottom)
            direction = 1;

        transform.Translate(0, speed * direction * Time.deltaTime, 0);
    }
}
