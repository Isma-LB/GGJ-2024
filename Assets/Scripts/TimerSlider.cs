using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    [SerializeField] RectTransform fill;
    [SerializeField] Image uiBG;
    [SerializeField] Sprite[] frames;
    
    void OnEnable()
    {
        GameManager.OnTimeChanged += HandleTimerChanged;
    }
    void OnDisable()
    {
        GameManager.OnTimeChanged -= HandleTimerChanged;
    }
    void HandleTimerChanged(float amount){
        amount = Mathf.Clamp01(amount);
        fill.anchorMax = new Vector2(amount,1);
        int index = Mathf.FloorToInt((1-amount) * (frames.Length-1));
        uiBG.sprite = frames[index];
    }
}
