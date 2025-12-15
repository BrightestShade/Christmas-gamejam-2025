using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [Header("Component")] 
    public TextMeshProUGUI timerText;

    [Header("Timer settings")]
    public float currentTime;
    public bool countDown;

    [Header("Timer Limit")]
    public bool hasLimit;
    public float timerLimit;

    void Start()
    {
        
    }

 
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        
        if(hasLimit && ((countDown && currentTime<=timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            
        }
        SetTimerText();
       
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }
}
