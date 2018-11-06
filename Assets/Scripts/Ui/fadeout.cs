using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeout : MonoBehaviour
{
    private float timer;
    public float timebeforefadein;
    public PlayerMovement playermovement;
    public BossSpawner bs;
    public bool firsttime = false;

    void Awake()
    {
        GameObject mp = GameObject.FindGameObjectWithTag("bossspawner");
        bs = mp.GetComponent<BossSpawner>();

        GameObject pm = GameObject.FindGameObjectWithTag("Player");
        playermovement = pm.GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (playermovement.currentlife == 0 && firsttime == false)
        {
            StartCoroutine(startimer());
            if (timer > timebeforefadein)
            {
                StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
                firsttime = true;
            }
        }
        if (bs.bossalive == false && firsttime == false)
        {
            StartCoroutine(startimer());
            if (timer > timebeforefadein)
            {
                StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
                firsttime = true;
            }
        }
    }
    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
    public IEnumerator startimer()
    {
        timer += Time.deltaTime;
        yield return null;
    }
}
