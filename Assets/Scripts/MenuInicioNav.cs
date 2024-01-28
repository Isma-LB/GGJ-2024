using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicioNav : MonoBehaviour
{
    [SerializeField]
    int scene = 1;
    

    public void Iniciar()
    {
        AudioEffectManager.Play(AudioEffects.click);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        AudioEffectManager.Play(AudioEffects.click);
        Application.Quit();
    }
}
