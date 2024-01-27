using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shake : MonoBehaviour
{
    public TMP_Text textField;
    public Image image;
    public AudioClip audioClip;
    AudioManager audioManager;

    private void Start()
    {
        // Obtener la instancia única del AudioManager
        audioManager = AudioManager.Instance;
    }

    public void ChangeTextValue(string newValue)
    {
        textField.text = newValue;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 valor = Input.acceleration;

        this.textField.text = valor.ToString();

        // Detectar si el dispositivo está volteado hacia arriba
        if (valor.y > 0.8f)
        {
            // Cambiar el color de la imagen a verde
            image.color = Color.green;
        }
        // Detectar si el dispositivo está volteado hacia abajo
        else if (valor.y < -0.8f)
        {
            // Cambiar el color de la imagen a azul
            image.color = Color.blue;
            audioManager.PlaySound(audioClip);
        }
    }
}
