using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 destionation = new Vector3();
    private Transform tr;

    void Start()
    {
        tr = transform;

        destionation = transform.position;
        destionation.x -= 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        tr.position = Vector3.MoveTowards(tr.position, destionation, 15 * Time.deltaTime);
    }
}
