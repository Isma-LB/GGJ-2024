using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparadores : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        StartCoroutine(Shot());
    }

    public void ShotBullet()
    {
        GameObject ap = Instantiate(bullet, transform.position, Quaternion.identity);
        Destroy(ap, 10);

        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        float numeroRandom = UnityEngine.Random.Range(2f, 6f);

        yield return new WaitForSeconds(numeroRandom);

        ShotBullet();
    }
}
