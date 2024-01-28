using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField, Range(0.5f, 2)] float fadeSpeed = 1;
    [SerializeField] CanvasGroup gameOverGroup = null;
    [SerializeField] Animator animatorCabeza = null;

    void Awake()
    {
        gameOverGroup.alpha = 0;
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }
    public void GameOver(){
        animatorCabeza.SetBool("GameOver", true);
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn(){
        float t = 0;
        while (t<1){
            t += Time.deltaTime * fadeSpeed;
            gameOverGroup.alpha = t;
            yield return null;
        }
        gameOverGroup.alpha = 1;
    }
}
