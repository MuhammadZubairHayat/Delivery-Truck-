using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManger : MonoBehaviour
{
    [Header("Level Instructions ")]
    public GameObject InstructionPanel;
    public string[] _instructions;
    public Text heading;
    public Text details;
    public int LevelCounter = 0;
    [Header("Animation Instructions ")]
    public GameObject AnimationPanel;
    public Text numberAnim;
    public Button start, home, next;
    string[] _animationsNumber= {"Go","3","2","1"};

    public static gameManger _gameManger;

    private void Awake()
    {
        if(_gameManger==null)
        {
            _gameManger = this;
        }

        start.gameObject.SetActive(true);
        GiveDataIn_InstuctionsPanel(LevelCounter);
        InstructionPanel.SetActive(true);

    }
    public void CompleteBtns()
    {
        start.gameObject.SetActive(false);
        home.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
    }
    public void GiveDataIn_InstuctionsPanel(int value)
    {
        details.text = _instructions[value];
        heading.text = "Level "+(LevelCounter+1);
    }

    public void OnClickHome()
    {
        Application.Quit();
    }

    public void OnclickNext()
    {
        TimerScript.instance.currentTime += 300f;
        TimerScript.instance.startTime =true;
        InstructionPanel.SetActive(false);
    }

    public void OnstartBtnClicked()
    {
        AnimationPanel.SetActive(true);
        InstructionPanel.SetActive(false);
        StartCoroutine(makeAnimationOfStartLevel(_animationsNumber.Length));
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator makeAnimationOfStartLevel(int value)
    {
        if((value - 1)<0)
        {
            TimerScript.instance.startTime = true;
            AnimationPanel.SetActive(false);
        }
        else
        {
            numberAnim.text = _animationsNumber[value - 1];
            yield return new WaitForSeconds(1f);
             StartCoroutine(makeAnimationOfStartLevel(value - 1));
        }
    }

}
