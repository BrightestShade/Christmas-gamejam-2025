using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    [Header("Component")] 
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highScoreText;

    [Header("Timer settings")]
    public float currentTime;
    public bool countDown;

    [Header("highScore settings")]
    public float fastestTime;
    


    [Header("Timer Limit")]
    public bool hasLimit;
    public float timerLimit;


    
    
    void Start()
    {
        fastestTime = PlayerPrefs.GetFloat("fastestTime", Mathf.Infinity);
        highScoreText.text = fastestTime == Mathf.Infinity
            ? "Fastest: 0.0"
            : "Fastest: " + fastestTime.ToString("0.0");
    }

 
    void Update()
    {
        
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        
        if(hasLimit && ((countDown && currentTime<=timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
           
        }
        SetTimerText();

        if (currentTime < fastestTime)
        {
            fastestTime = currentTime;
            PlayerPrefs.SetFloat("fastestTime", fastestTime);
            highScoreText.text = "Fastest: " + fastestTime.ToString("0.0");
        }
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }

}
