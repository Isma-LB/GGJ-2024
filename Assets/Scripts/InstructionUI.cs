using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionUI : MonoBehaviour
{
    [SerializeField] CanvasGroup miniGameBG = null;
    [SerializeField] TextMeshProUGUI instructionText = null;
    [SerializeField] TextMeshProUGUI playerText = null;
    public void Show(string text, string player){
        miniGameBG.alpha = 0;
        instructionText.text = text;
        playerText.text = player;
    }
    public void Hide(){
        miniGameBG.alpha = 1;
    }
}
