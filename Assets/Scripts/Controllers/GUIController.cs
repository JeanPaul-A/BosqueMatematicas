using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    private Text txtExercise;
    private Text txtScore;
    private Slider sldTime;
    private Text txtMessage;
    private GameObject gameOverSign;
    private GameObject pause;

    void Awake()
    {
        txtExercise = canvas.transform.Find("Exercise").transform.Find("txtExercise").GetComponent<Text>();
        txtScore = canvas.transform.Find("Score").transform.Find("txtScore").GetComponent<Text>();
        sldTime = canvas.transform.Find("Time").GetComponent<Slider>();
        txtMessage = canvas.transform.Find("Message").GetComponent<Text>();
        gameOverSign = canvas.transform.Find("GameOverSign").gameObject;
        pause = canvas.transform.Find("Pause").gameObject;
    }

    public void AlterPauseActive()
    {
        Debug.Log(pause.activeSelf);
        pause.SetActive(!pause.activeSelf);
    }

    public void ActiveGameOverSign(bool enable)
    {
        gameOverSign.SetActive(enable);
    }

    public void SetMessageText(string message)
    {
        txtMessage.text = message;
    }

    public void AlterMessageEnable(bool enable)
    {
        txtMessage.enabled = enable;
    }

    public void SetExercise(string exercise)
    {
        txtExercise.text = exercise;
    }

    public void SetScore(string score)
    {
        txtScore.text = score;
    }

    public void SetSlider(int maxSlider)
    {
        sldTime.maxValue = maxSlider;
        sldTime.value = maxSlider;
    }

    public void ChangeSlider()
    {
        sldTime.value--;
    }

}
