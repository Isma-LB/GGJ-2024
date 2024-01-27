using UnityEngine;

[CreateAssetMenu(menuName = "GGJ-2024/minijuego")]
public class MiniJuego : ScriptableObject
{
    [Header("Scene")]
    [SerializeField] string sceneName = "";
    [SerializeField, Range(0, 60)] float miniGameTime = 10f;
    [SerializeField, Range(0, 3)] float timeReducer = 0.5f;


    [Header("Instruction")]
    [SerializeField, TextArea()] public string instructionText = "";
    [SerializeField, Range(0,30)] public float instructionTime = 5.0f;


    public string SceneName { get => sceneName; }
    public float MiniGameTime { get => miniGameTime - timesPlayed * timeReducer; }
    public void WasPlayed(){
        timesPlayed++;
    }
    public void Reset(){
        timesPlayed = 0;
    }
    int timesPlayed = 0;

}