using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMiniGame : MonoBehaviour
{
    public MicrophoneManager ruido;
    public float Timer;
    public Transform upPos;
    public Transform downPos;
    public float velocity;

    private Transform tr;

    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        float limitador = ruido.GetRuido();

        if(limitador >= 10)
        {
            limitador = 10;
        }

        if (limitador > 0.8f)
        {
            tr.position = Vector3.MoveTowards(tr.position, upPos.position, limitador * Time.deltaTime);
        }
        else
        {
            tr.position = Vector3.MoveTowards(tr.position, downPos.position, velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "bullet")
        {
            print("perdiste");
        }
    }
}
