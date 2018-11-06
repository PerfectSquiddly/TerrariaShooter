using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRight : MoveUpAndDown {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x >= 5)
        {
            direction = -1;
        }

        if (transform.position.x <= -5)
        {
            direction = 1;
        }
        transform.Translate(enemyspeed * direction * Time.deltaTime, 0, 0);

    }
}
