using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayersSO players = null;
    [SerializeField] List<MiniJuego> miniJuegos = null;
    
    [SerializeField] InstructionUI instructionUI = null;
    MiniJuego current;
    string currentPlayer; 
    IEnumerator currentMiniGame;
 
    public delegate void TimerChanged(float amount);
    public static event TimerChanged OnTimeChanged;
    public delegate void MenuStateChange(bool isOpen);
    public static event MenuStateChange OnMenuStateChange;



    static GameManager instance;

    public static void MiniGameSolved() {
        if(instance != null) instance.Solved(); else Debug.Log("GameManager: Minigame solved!");
    }   
    void Solved(){
        Debug.Log("SOLVED");
        StopCoroutine(currentMiniGame);
        SceneManager.UnloadSceneAsync(current.SceneName);
        current.WasPlayed();
        current = null;
    }
    void GameOver(){
        OnTimeChanged?.Invoke(0);
        SceneManager.UnloadSceneAsync(current.SceneName);
        Debug.Log("Game Over");
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        gameOverUI.GameOver();
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
        foreach (MiniJuego game in miniJuegos)
        {
            game.Reset();
        }
    }
    void Update()
    {
        if(current == null){
            // chose a mini game
            current = GetRandomMiniJuego();
            // choose a player
            currentPlayer = players.GetNextPlayer();
            // play minigame scene 
            currentMiniGame = PlayMiniGame(current, currentPlayer);
            StartCoroutine(currentMiniGame);
        }
    }

    IEnumerator PlayMiniGame(MiniJuego game, string player){
        yield return ShowInstruction(game, player);
        SceneManager.LoadScene(game.SceneName, LoadSceneMode.Additive);
        yield return HandleTimer(game.MiniGameTime);
        // game over
        GameOver();
    }

    IEnumerator ShowInstruction(MiniJuego current, string player)
    {
        instructionUI.Show(current.instructionText, player);
        OnMenuStateChange?.Invoke(true);
        yield return instructionUI.Count(current.instructionTime);
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
