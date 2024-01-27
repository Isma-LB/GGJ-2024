using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<string> players = null;
    [SerializeField] List<MiniJuego> miniJuegos = null;
    [SerializeField] CanvasGroup miniGameBG = null;
    [SerializeField] TextMeshProUGUI instructionText = null;
    MiniJuego current;
    IEnumerator currentMiniGame;
 
    public delegate void TimerChanged(float amount);
    public static event TimerChanged OnTimeChanged;
    public delegate void MenuStateChange(bool isOpen);
    public static event MenuStateChange OnMenuStateChange;



    static GameManager instance;

    public static void MiniGameSolved() {
        if(instance != null){
            instance.Solved();
        }
        else {
            Debug.Log("GameManager: Minigame solved!");
        }
    }   
    void Solved(){
        Debug.Log("SOLVED");
        StopCoroutine(currentMiniGame);
        SceneManager.UnloadSceneAsync(current.SceneName);
        current.WasPlayed();
        current = null;
    }
    void Awake()
    {
        // Singleton guard
        if(instance==null) instance = this; else Destroy(this);
    }
    // Free singleton if needed
    void OnDestroy() { if(instance == this) instance = null; }

    void Start()
    {
        foreach (MiniJuego juego in miniJuegos)
        {
            juego.Reset();
        }
    }
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
        yield return ShowInstruction(current);
        SceneManager.LoadScene(current.SceneName, LoadSceneMode.Additive);
        yield return HandleTimer(current.MiniGameTime);
        // game over
        OnTimeChanged?.Invoke(0);
        SceneManager.UnloadSceneAsync(current.SceneName);
        Debug.Log("Game Over");
    }

    IEnumerator ShowInstruction(MiniJuego current)
    {
        instructionText.text = current.instructionText;
        miniGameBG.alpha = 0;
        OnMenuStateChange?.Invoke(true);
        yield return new WaitForSeconds(current.instructionTime);
        miniGameBG.alpha = 1;
        OnMenuStateChange?.Invoke(false);
    }

    IEnumerator HandleTimer(float startTime){
        Debug.Log("timer started" + startTime);
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
