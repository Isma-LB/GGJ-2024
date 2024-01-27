using UnityEngine;

[CreateAssetMenu(menuName = "GGJ-2024/minijuego")]
public class MiniJuego : ScriptableObject
{
    [Range(0,60)]
    public float time = 0.5f;
    [SerializeField] string sceneName = "";

    public string SceneName { get => sceneName; }

}