using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyMiniGame : MonoBehaviour
{
    public MicrophoneManager ruido;
    public Transform upPos;
    public Transform downPos;
    public float velocity;
    public int limit;
    float limitador;
    [SerializeField, Range(1,10)] float maxHeight = 5;
    public TextMeshProUGUI text;

    private Transform tr;

    private int objectsCollected = 0;

    void Start()
    {
        Contador();

        tr = transform;
    }

    private void Contador()
    {
        text.text = objectsCollected + " / " + limit;
    }

    private void LateUpdate()
    {
        limitador = Mathf.Lerp(limitador, ruido.GetRuido(), 0.25f ) ;
        tr.position = Vector3.Lerp(downPos.position, upPos.position, limitador);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            objectsCollected += 1;
            Contador();
            Destroy(collision.gameObject);

            if (objectsCollected >= limit)
            {
                GameManager.MiniGameSolved();
            }
        }
    }
}
