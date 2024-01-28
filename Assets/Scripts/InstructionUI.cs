using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionText = null;
    [SerializeField] TextMeshProUGUI playerText = null;
    [SerializeField] TextMeshProUGUI countText = null;
    bool soundPlayed = false;
    public void Show(string text, string player){
        instructionText.text = text;
        playerText.text = player;
        countText.text = "";
        soundPlayed = false;
    }
    public IEnumerator Count(float time){
        float timer = time;
        while(timer > 0){
            timer -= Time.deltaTime;
            if(timer < 3){
                if(soundPlayed == false){
                    AudioEffectManager.Play(AudioEffects.clack);
                    soundPlayed = true;
                }
                countText.text = Mathf.CeilToInt(timer).ToString();
            }
            yield return null;
        }

    }
}
