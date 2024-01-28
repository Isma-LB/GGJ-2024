using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shake : MonoBehaviour
{
    // REQUIRED VARIABLES
    public GameObject scorpion;
    public int poolSize = 5;
    public List<GameObject> scorpionPool;

    public float shakeForce = 5;
    public float rango = 3.6f;
    public float minimoIntervalo = 0.2f;
    [SerializeField] private float raizRango;
    [SerializeField] private float ultimoTiempo;
    private int puntero;
    private Camera cam;

    private bool isShaking;

    private void Start()
    {
        raizRango = Mathf.Pow(rango, 2);
        cam = Camera.main;
        scorpionPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(scorpion);
            obj.SetActive(false);
            scorpionPool.Add(obj);
        }


        foreach (var s in scorpionPool)
        {
            float randomX = Random.Range(0, Screen.width);
            float randomY = Random.Range(0, Screen.height);
            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(randomX, randomY, +10));
            GameObject obj = GetPooledObject();
            if (obj != null)
            {
                obj.transform.position = worldPos;
                obj.SetActive(true);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < scorpionPool.Count; i++)
        {
            if (!scorpionPool[i].activeInHierarchy)
            {
                return scorpionPool[i];
            }
        }
        return null;
    }

    public void ShakeScorpions(Vector3 aceleration)
    {
        var aux = scorpionPool[puntero].GetComponent<Rigidbody>();
        aux.constraints &= ~RigidbodyConstraints.FreezePositionX;
        aux.constraints &= ~RigidbodyConstraints.FreezePositionY;
        aux.AddForce(aceleration * shakeForce, ForceMode.Impulse );
        StartCoroutine(DestroyGO(this.puntero));
        puntero++;
        isShaking = true;
    }


    void Update()
    {
        if ((Input.acceleration.magnitude >= rango && Time.unscaledTime >= ultimoTiempo + minimoIntervalo)|| Input.GetKey(KeyCode.O))
        {
           Debug.Log("isShaking");
           if (!isShaking)
            {
                StartCoroutine(shake());
            }
        }
        if (scorpionPool[poolSize - 1].IsDestroyed())
        {
            StartCoroutine(WinGame());
        }
    }

    IEnumerator shake()
    {
        this.ShakeScorpions(Input.acceleration);
        Handheld.Vibrate();
        ultimoTiempo = Time.unscaledTime;
        yield return new WaitForSeconds(1);
        Debug.Log("Is Not Shaking");
        isShaking =false;
    }

    IEnumerator DestroyGO(int puntero)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Objeto Destruido");
        Destroy(scorpionPool[puntero]);
    }

    IEnumerator WinGame()
    {
        Handheld.Vibrate();
        yield return new WaitForSeconds(0.5f);
        GameManager.MiniGameSolved();
    }
}
