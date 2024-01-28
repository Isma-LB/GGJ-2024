using System;
using System.Collections;
using System.Collections.Generic;
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

    public Image image;
    public AudioClip audioClip;
    AudioManager audioManager;

    private void Start()
    {
        raizRango = Mathf.Pow(rango, 2);
        audioManager = AudioManager.Instance;

        scorpionPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(scorpion);
            obj.SetActive(false);
            scorpionPool.Add(obj);
        }

        foreach (var s in scorpionPool)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4.5f, 4.5f), 0f);
            GameObject obj = GetPooledObject();
            if (obj != null)
            {
                obj.transform.position = randomPosition;
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
        scorpionPool[puntero].GetComponent<Rigidbody>().AddForce(aceleration * shakeForce, ForceMode.Impulse );
        Debug.Log(puntero);
        puntero++;
    }


    void Update()
    {
        if (Input.acceleration.magnitude >= rango && Time.unscaledTime >= ultimoTiempo + minimoIntervalo)
        {
            this.ShakeScorpions(Input.acceleration);     
           ultimoTiempo = Time.unscaledTime;
        }

        //p+oner un flag restar Time.deltatime
        
    }
}
