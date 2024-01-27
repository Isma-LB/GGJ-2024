using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneManager : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;

    public float vibrationDuration = 0.5f;

    void Start()
    {
        MicrophonetToAudioclip();
    }

    public float GetRuido()
    {
        float ruido = (GetLoundnessFromMicrophone() * 100);

        if (ruido < 0.1f) ruido = 0;

        return ruido;
    }

    private void MicrophonetToAudioclip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoundnessFromMicrophone()
    {
        return GetLoundnessFromAudioclip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoundnessFromAudioclip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0) return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoundness = 0;

        for(int i = 0; i < sampleWindow; i++)
        {
            totalLoundness += Mathf.Abs(waveData[i]);
        }

        return totalLoundness / sampleWindow;
    }
}
