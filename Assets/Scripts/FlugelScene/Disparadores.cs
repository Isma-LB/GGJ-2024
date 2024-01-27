using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparadores : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShotBullet()
    {
        GameObject ap = Instantiate(bullet, transform.position, Quaternion.identity);
        Destroy(ap, 10);


    }
}
