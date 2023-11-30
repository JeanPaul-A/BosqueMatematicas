using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] LevelController levelController;
    [SerializeField] ProblemsGenerator problemsGenerator;
    [SerializeField] BunniesController bunniesController;
    [SerializeField] GUIController guiController;
    [SerializeField] GameObject MainController;
    [SerializeField] BackgroundMovement[] backgroundMovement;

    private SelectController selectController;
    private bool playing = true;
    private int totalSeconds;
    public void SetTotalSeconds(int totalSeconds)
    {
        this.totalSeconds = totalSeconds;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ControlPlaying();
            guiController.AlterPauseActive();
        }
    }

    void Start()
    {
        selectController = MainController.transform.Find("SelectController").GetComponent<SelectController>();
        StartCoroutine(StartTime());
    }

    public void ControlPlaying()
    {
        playing = !playing;
        foreach (var background in backgroundMovement)
        {
            background.AlterBackgroundSpeed();
        }
        if (playing)
        {
            StartCoroutine(CountSeconds());
        }

    }

    IEnumerator StartTime()
    {
        guiController.AlterMessageEnable(true);
        guiController.SetMessageText("Listo?");
        yield return new WaitForSeconds(2);
        guiController.SetMessageText("Go!");
        yield return new WaitForSeconds(1);
        guiController.AlterMessageEnable(false);
        problemsGenerator.StartGame();
    }

    public void SetSlider()
    {
        totalSeconds = 16 - (1 * levelController.GetActualLevel());
        guiController.SetSlider(totalSeconds);
        StartCoroutine(CountSeconds());
    }

    IEnumerator CountSeconds()
    {
        while (totalSeconds > 0 && playing)
        {
            yield return new WaitForSeconds(1);
            totalSeconds--;
            guiController.ChangeSlider();
        }
        if (totalSeconds == 0)
        {
            StartCoroutine(problemsGenerator.NewGame());
        }
    }

}
