using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    void OnEnable()
    {
        GameManager.OnMenuStateChange += HandleIsOnMenu;
    }
    void OnDisable()
    {
        GameManager.OnMenuStateChange += HandleIsOnMenu;
    }
    void HandleIsOnMenu(bool isOpen)
    {

    }
}
