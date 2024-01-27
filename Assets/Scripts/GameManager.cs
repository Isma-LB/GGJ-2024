using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<string> players = null;
    [SerializeField] List<MiniJuego> miniJuegos = null;
    [SerializeField] CanvasGroup miniGameBG = null;
 
    public delegate void TimerChanged(float amount);
    public static event TimerChanged OnTimeChanged;
    public delegate void MenuStateChange(bool isOpen);
    public static event MenuStateChange OnMenuStateChange;



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
        current = null;
    }
    void Awake()
    {
        // Singleton guard
        if(instance==null) instance = this; else Destroy(this);
    }
    // Free singleton if needed
    void OnDestroy() { if(instance == this) instance = null; }
    // Start is called before the first frame update
    void Update()
    {
        if(current == null){
            // chose a mini game
            current = GetRandomMiniJuego();
            // play minigame scene 
            currentMiniGame = PlayMiniGame(current);
            StartCoroutine(currentMiniGame);
        }
    }

    IEnumerator PlayMiniGame(MiniJuego current){
        yield return ShowInstruction();
        SceneManager.LoadScene(current.SceneName, LoadSceneMode.Additive);
        yield return HandleTimer(current.time);
        // game over
        OnTimeChanged?.Invoke(0);
        SceneManager.UnloadSceneAsync(current.SceneName);
        Debug.Log("Game Over");
    }

    IEnumerator ShowInstruction()
    {
        miniGameBG.alpha = 0;
        OnMenuStateChange?.Invoke(true);
        yield return new WaitForSeconds(5);
        miniGameBG.alpha = 1;
        OnMenuStateChange?.Invoke(false);
    }

    IEnumerator HandleTimer(float startTime){
        float timer = startTime;
        while(timer > 0){
            timer -= Time.deltaTime;
            OnTimeChanged?.Invoke(timer / startTime);
            yield return null;
        }
    }
    MiniJuego GetRandomMiniJuego(){
        int index = Random.Range(0, miniJuegos.Count);
        return miniJuegos[index];
    }

    
}
