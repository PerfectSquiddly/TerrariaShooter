﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalSpawner : BossSpawner
{
    public SpazMatism sm;
    public Retinazer rz;
    public MoveBettwenTargets ms;
    public SkeletronprimeMovement spm;
    private bool spazmatismisalive = true;
    private bool retinazerisalive = true;


    public GameObject secondboss;
    public GameObject secondeyeboss;
    public GameObject thirdboss;
    private bool playonce;
    private bool playoncesecond;
    private bool playoncethird;
    private bool stopplz;

    private bool firstbossdead = false;
    private bool secondbossdead = false;
    // Use this for initialization
    void Start()
    {
        victoryscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnin());
    }
    public IEnumerator spawnin()
    {
        if (!bossspawn && Time.timeSinceLevelLoad > 30)//30
        {
            wheretospawn = new Vector2(15f, 0f);
            Instantiate(Boss, wheretospawn, Quaternion.identity);
            ms = GameObject.FindGameObjectWithTag("Boss").GetComponent<MoveBettwenTargets>();
            bossspawn = true;
        }
        if (bossspawn == true && ms.life < 1)
        {
            firstbossdead = true;
        }
        if (firstbossdead == true && playonce == false)
        {
            playonce = true;
            yield return new WaitForSeconds(1);
            Instantiate(secondeyeboss, new Vector2(6.96f, -4f), Quaternion.identity);
            Instantiate(secondboss, new Vector2(6.96f, 0f), Quaternion.identity);

            GameObject spaztism = GameObject.Find("Spaztism(Clone)");
            sm = spaztism.GetComponent<SpazMatism>();

            GameObject retinazer = GameObject.Find("Retinazer(Clone)");
            rz = retinazer.GetComponent<Retinazer>();
            bossspawn = true;
        }

        //check if twins are alive
        if (firstbossdead == true && secondbossdead == false)
        {
            if (rz.life < 1)
            {
                retinazerisalive = false;
            }
            if (sm.life < 1)
            {
                spazmatismisalive = false;
            }
            if (spazmatismisalive == false && retinazerisalive == false)
            {
                secondbossdead = true;
            }
        }

        if (secondbossdead == true && playoncesecond == false)
        {
            playoncesecond = true;
            yield return new WaitForSeconds(1);
            Instantiate(thirdboss, new Vector2(4f, 0f), Quaternion.identity);
            spm = GameObject.FindGameObjectWithTag("Boss").GetComponent<SkeletronprimeMovement>();
        }

        if (playoncesecond == true && spm.life < 1 && secondbossdead == true && playoncethird == false)
        {
            playoncethird = true;
            StartCoroutine(timerbeforevictory());
        }
    }
}
