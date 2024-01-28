using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionUI : MonoBehaviour
{
    [SerializeField] CanvasGroup miniGameBG = null;
    [SerializeField] TextMeshProUGUI instructionText = null;
    [SerializeField] TextMeshProUGUI playerText = null;
    [SerializeField] TextMeshProUGUI countText = null;
    public void Show(string text, string player){
        miniGameBG.alpha = 0;
        instructionText.text = text;
        playerText.text = player;
        countText.text = "";
    }
    public IEnumerator Count(float time){
        float timer = time;
        while(timer > 0){
            timer -= Time.deltaTime;
            if(timer < 3){
                countText.text = Mathf.CeilToInt(timer).ToString();
            }
            yield return null;
        }

    }
    public void Hide(){
        miniGameBG.alpha = 1;
    }
}
