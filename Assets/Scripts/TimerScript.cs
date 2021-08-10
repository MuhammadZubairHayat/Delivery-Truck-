using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentTime;
    public Text time;
    public GameObject gameFail;
    float minutes;
    float seconds;
    public bool startTime = false;
    public static TimerScript instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            currentTime -= Time.deltaTime;
            minutes = Mathf.FloorToInt(currentTime / 60);
            seconds = Mathf.FloorToInt(currentTime % 60);
            if (currentTime >= 0)
            {
                time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                gameFail.SetActive(true);
            }
        }
    }
}
