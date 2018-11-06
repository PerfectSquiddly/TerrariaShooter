using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShootingenemy : Enemydemonmovement

{
    public float buletspeed;
    public float negativerotation;
    public float maxrotation;
    private void Update()
    
    {
        if (Canshoot == false)
        {
            movetoleft();
        }
        if (Canshoot == true)
        {
            StartCoroutine(movement());
            StartCoroutine(Spreadshot());
        }
    }
    public IEnumerator Spreadshot()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            for (int i = 0; i < 9; i++)
            {
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, bulletroation)));
                Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, -bulletroation)));
                bulletroation += 5;
            }
        }
        if (bulletroation == maxrotation)
        {
            bulletroation = 0;
        }

        yield return null;
    }
    
}
