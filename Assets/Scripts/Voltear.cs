using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Voltear : MonoBehaviour
{
    public Image image;
    public AudioClip audioClip;
    AudioManager audioManager;
    public bool isGreen;
    public float greenTime;

    private void Start()
    {
        audioManager = AudioManager.Instance;
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
                image.color = Color.green;
                isGreen = true;
                greenTime += Time.deltaTime;

                if (greenTime > 1f)
                {
                GameManager.MiniGameSolved();
                }
            }
            else
            {
                isGreen = false;
                greenTime += 0;
                image.color = Color.blue;
            }
            Debug.Log("El giroscopio está disponible en este dispositivo.");
        }
        else
        {
            GameManager.MiniGameSolved();
            image.color = Color.red;
            Debug.Log("El giroscopio no está disponible en este dispositivo.");
        }
    }

}

