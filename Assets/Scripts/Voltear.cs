using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.Collections;

public class Voltear : MonoBehaviour
{
    public bool isGreen;
    public float greenTime;

    [SerializeField]
    float timeToWin = 1.0f;

    [SerializeField]
    Animator animator;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var gyroValue = Input.gyro.attitude.eulerAngles;

        if (SystemInfo.supportsGyroscope)
        {
            if ((gyroValue.x >= 355 || gyroValue.x <= 10) && (gyroValue.y >= 170 && gyroValue.y <= 190))
            {
                Handheld.Vibrate();
                isGreen = true;
                greenTime += Time.deltaTime;

                    StartCoroutine(WaitToWin());
            }
            else
            {
                isGreen = false;
                greenTime += 0;
            }
            Debug.Log("El giroscopio est� disponible en este dispositivo.");
        }
        else
        {
            //GameManager.MiniGameSolved();
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(WaitToWin());
            }
            Debug.Log("El giroscopio no est� disponible en este dispositivo.");
        }
    }

    public IEnumerator WaitToWin()
    {
        animator.Play("TortugaPie");
        yield return new WaitForSeconds(timeToWin);
        GameManager.MiniGameSolved();

    }
}

