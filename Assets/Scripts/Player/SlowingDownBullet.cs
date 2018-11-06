using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingDownBullet : BulletScript
{

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(velocityX > 1f)
        {
        velocityX -= 0.9f * Time.deltaTime;
        }
        rb.velocity = transform.right * -velocityX;
    }
}
