using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new audioEffect", menuName = "Audio/AudioEffect")]
public class AudioEffect : ScriptableObject
{
    [SerializeField] AudioClip audioClip = null;
    [Range(0,2)]
    [SerializeField] float pitch = 1;
    [Range(0,1)]
    [SerializeField] float volume = 1;
    [Range(0,1)]
    [SerializeField] float pitchVariation = 0f;
    [Range(0,1)]
    [SerializeField] float volumeVariation = 0f;

    public void Play(AudioSource audioSource){
        audioSource.pitch = pitch + Random.Range(-pitchVariation,pitchVariation);
        audioSource.volume = volume + Random.Range(-volumeVariation,volumeVariation);
        audioSource.PlayOneShot(audioClip);
    }
}
