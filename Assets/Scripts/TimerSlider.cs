using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSlider : MonoBehaviour
{
    [SerializeField] RectTransform fill;
    [SerializeField, Range(0,1)] float value = 0.5f; 
    
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
    }
}
