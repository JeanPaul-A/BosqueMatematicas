using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GUIController guiController;
    [SerializeField] GameObject[] bunnyHeads;
    [SerializeField] GameObject MainController;
    private TimeController timeController;

    private int actualLevel = 1;
    private int actualScore = 0;
    private bool gameOver = false;
    public int GetActualLevel()
    {
        return actualLevel;
    }

    private void Awake()
    {
        timeController = MainController.transform.Find("TimeController").GetComponent<TimeController>();
    }

    private void Start()
    {
        VisualizeLevel();
    }

    public void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (actualLevel == 10 && !gameOver)
        {
            timeController.ControlPlaying();
            guiController.ActiveGameOverSign(true);
            gameOver = true;
        }
    }

    public void ChangeLevel(bool isLevel)
    {
        actualLevel += isLevel ? 1 : -1;
        actualLevel = Mathf.Clamp(actualLevel, 1, 10);
        VisualizeLevel();
    }

    public void ChangeScore(bool isScore)
    {
        actualScore += (isScore) ? actualLevel * 5 : -actualLevel * 2;
        actualScore = Mathf.Clamp(actualScore, 0, int.MaxValue);
        guiController.SetScore(actualScore.ToString());
    }


    public void VisualizeLevel()
    {
        for (int i = 0; i < bunnyHeads.Length; i++)
        {
            bool isActive = (i < actualLevel) ? true : false;
            bunnyHeads[i].SetActive(isActive);
        }
    }
}
