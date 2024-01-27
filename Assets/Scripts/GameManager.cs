using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<string> players = null;
    [SerializeField] List<MiniJuego> miniJuegos = null;
 
    public delegate void TimerChanged(float amount);
    public static event TimerChanged OnTimeChanged;

    static GameManager instance;

    MiniJuego current;
    IEnumerator currentMiniGame;
    public static void MiniGameSolved() {
        instance.Solved();
    }   
    void Solved(){
        Debug.Log("SOLVED");
        StopCoroutine(currentMiniGame);
        SceneManager.UnloadSceneAsync(current.name);
        current = GetRandomMiniJuego();
        currentMiniGame = PlayMiniGame(current);
        StartCoroutine(currentMiniGame);
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        current = GetRandomMiniJuego();
        currentMiniGame = PlayMiniGame(current);
        StartCoroutine(currentMiniGame);
    }

    IEnumerator PlayMiniGame(MiniJuego current){
        SceneManager.LoadScene(current.SceneName, LoadSceneMode.Additive);
        float timer = current.time;
        while(timer > 0){
            timer -= Time.deltaTime;
            OnTimeChanged?.Invoke(timer / current.time);
            yield return null;
        }
        OnTimeChanged?.Invoke(0);
        SceneManager.UnloadSceneAsync(current.SceneName);
        Debug.Log("Game Over");
    }
    MiniJuego GetRandomMiniJuego(){
        int index = Random.Range(0, miniJuegos.Count);
        return miniJuegos[index];
    }
}
