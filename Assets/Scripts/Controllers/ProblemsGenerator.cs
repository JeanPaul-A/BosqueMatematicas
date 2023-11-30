using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static BunniesController;
using Random = UnityEngine.Random;

public class ProblemsGenerator : MonoBehaviour
{
    [SerializeField] GUIController GUIController;
    [SerializeField] TimeController timeController;

    private GameObject[] bunnies;
    public void SetBunniesSpawned(GameObject[] bunniesSpawned)
    {
        bunnies = bunniesSpawned;
    }

    private int result;
    public int GetResult()
    {
        return result;
    }
    private int[] options;
    private int whereResult;

    public void StartGame()
    {
        GenerateProblems();
        GenerateOptions();
        for (int i = 0; i < bunnies.Length; i++)
        {
            bunnies[i].transform.Find("Sign").transform.Find("Canvas").transform.Find("Number").gameObject.GetComponent<TextMeshProUGUI>().text = options[i].ToString();
        }
        timeController.SetSlider();
    }

    public IEnumerator NewGame()
    {
        yield return new WaitForSeconds(1);
        StartGame();
    }

    public void GenerateProblems()
    {
        int op1 = Mathf.RoundToInt(Random.Range(0, 11));
        int op2 = Mathf.RoundToInt(Random.Range(0, 11));

        result = op1 + op2;
        String exercise = op1 + " + " + op2;

        GUIController.SetExercise(exercise);
    }

    void GenerateOptions()
    {
        whereResult = Mathf.RoundToInt(Random.Range(0, 5));

        options = new int[5];
        for (int i = 0; i < options.Length; i++)
        {
            if (i == whereResult)
            {
                options[i] = result;
            }
            else
            {
                options[i] = Mathf.RoundToInt(Random.Range(0, 21));
            }
        }
    }
}
