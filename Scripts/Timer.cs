using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    private float startTime;
    private bool finnished = false;
    int minuteTime;//for if statement
    string minutes;//player timer
    string seconds;//player timer

    void Start()
    {
        startTime = Time.time;//timer starts on application start
    }

    void Update()
    {
        if (finnished)
        {
            return;//stops timer
        }
        float t = Time.time - startTime;
        
        float s = Time.time - startTime;//separate timer that player can't see, int type to create if statement
        minuteTime = ((int)s / 60);//only checks minutes

        
        minutes = ((int) t / 60).ToString();
        seconds = (t % 60).ToString("f2");//displays 2 digits

        timerText.text = minutes + ":" + seconds;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Win"))//collides with win tag, timer stops and color yellow
        {
            finnished = true;
            timerText.color = Color.yellow;
            StartCoroutine(WaitForSceneLoad());

            if (minuteTime < 1)
            {
                timerText.text = minutes.ToString() + ":" + seconds.ToString() + "<br>Wow, you scored below 1 minute";//player win text
            }
            if(minuteTime >= 1)
            {
                timerText.text = minutes.ToString() + ":" + seconds.ToString() + "<br>Better luck next time";//player lose text
            }
        }  
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3);//waits 3 seconds before loading new scene
        SceneManager.LoadScene("WinScreen");
        Cursor.visible = true;//player  can see cursor
        Cursor.lockState = CursorLockMode.None;//player can move cursor
    }
}
