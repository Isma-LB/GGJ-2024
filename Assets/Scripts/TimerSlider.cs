using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    
    [SerializeField] CanvasGroup canvasAlpha = null;
    [SerializeField] RectTransform fill = null;
    [SerializeField] Image uiBG;
    [SerializeField] Sprite[] frames;
    
    void OnEnable()
    {
        GameManager.OnTimeChanged += HandleTimerChanged;
        GameManager.OnMenuStateChange += HandleMenuStateChanged;
    }
    void OnDisable()
    {
        GameManager.OnTimeChanged -= HandleTimerChanged;
        GameManager.OnMenuStateChange -= HandleMenuStateChanged;
    }
    void HandleTimerChanged(float amount){
        amount = Mathf.Clamp01(amount);
        fill.anchorMax = new Vector2(amount,1);
        int index = Mathf.FloorToInt((1-amount) * (frames.Length-1));
        uiBG.sprite = frames[index];
    }
    void HandleMenuStateChanged(bool isOpen){
        canvasAlpha.alpha = isOpen? 0 : 1;
        AudioEffectManager.Play(isOpen? AudioEffects.end : AudioEffects.start );
    }
}
