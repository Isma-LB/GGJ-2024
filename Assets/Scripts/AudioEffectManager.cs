using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioEffects { clack, click, cuenta_regresiva, escorpion, game_over, glup, metronomo, risa_burla, tortuga, victoria, start, end }

public class AudioEffectManager : MonoBehaviour
{
    [Header("Audio effects")]
    [SerializeField] AudioEffect clack = null;
    [SerializeField] AudioEffect click = null;
    [SerializeField] AudioEffect cuenta_regresiva = null;
    [SerializeField] AudioEffect escorpion = null;
    [SerializeField] AudioEffect game_over = null;
    [SerializeField] AudioEffect glup = null;
    [SerializeField] AudioEffect metronomo = null;
    [SerializeField] AudioEffect risa_burla = null;
    [SerializeField] AudioEffect tortuga = null;
    [SerializeField] AudioEffect victoria = null;
    [SerializeField] AudioEffect start = null;
    [SerializeField] AudioEffect end = null;


    [Header("Audio Sources")]
    [SerializeField] AudioSource effectsAudioSource = null;
    public static AudioEffectManager instance = null;

    private void PlayEffect(AudioEffects effect)
    {
        switch (effect)
        {
            case AudioEffects.clack: clack.Play(effectsAudioSource); break;
            case AudioEffects.click: click.Play(effectsAudioSource); break;
            case AudioEffects.cuenta_regresiva: cuenta_regresiva.Play(effectsAudioSource); break;
            case AudioEffects.escorpion: escorpion.Play(effectsAudioSource); break;
            case AudioEffects.game_over: game_over.Play(effectsAudioSource); break;
            case AudioEffects.glup: glup.Play(effectsAudioSource); break;
            case AudioEffects.metronomo: metronomo.Play(effectsAudioSource); break;
            case AudioEffects.risa_burla: risa_burla.Play(effectsAudioSource); break;
            case AudioEffects.tortuga: tortuga.Play(effectsAudioSource); break;
            case AudioEffects.victoria: victoria.Play(effectsAudioSource); break;
            case AudioEffects.start: start.Play(effectsAudioSource); break;
            case AudioEffects.end: end.Play(effectsAudioSource); break;
        }
    }
    // function to make the singelton static
    private void Awake() {
        AudioEffectManager[] objs = FindObjectsOfType<AudioEffectManager>();
        if(objs.Length >1){
            Destroy(this.gameObject);
        }
        else{
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Play(AudioEffects.clack);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Play(AudioEffects.click);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Play(AudioEffects.cuenta_regresiva);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Play(AudioEffects.escorpion);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Play(AudioEffects.game_over);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Play(AudioEffects.glup);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Play(AudioEffects.metronomo);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Play(AudioEffects.risa_burla);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Play(AudioEffects.tortuga);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Play(AudioEffects.victoria);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Play(AudioEffects.start);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Play(AudioEffects.end);
        }
    }


    public static void Play(AudioEffects effect){
        if(instance == null) return;
        instance.PlayEffect(effect);
    }
}
