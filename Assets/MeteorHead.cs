using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHead : Dukenado
{
    public float currentrotation;
    public float roationtoAdd;
    public float maxrotation;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.forward, SpinnSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.AngleAxis(0, Vector3.zero);

        StartCoroutine(SpinShot());
    }
    public IEnumerator SpinShot()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, currentrotation)));
            currentrotation += roationtoAdd;
        }
        if (currentrotation == 45 || currentrotation == -45)
        {
            currentrotation = 0;
        }
        //Instantiate(enemybullet, transform.position, Quaternion.Euler(new Vector3(0, 0, -bulletroation)));
        //bulletroation += 5;
        yield return null;
    }
}