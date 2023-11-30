using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField] ProblemsGenerator problemsGenerator;
    [SerializeField] LevelController levelController;
    [SerializeField] TimeController timeController;
    [SerializeField] AudioController audioController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit2D.collider != null)
            {
                GameObject bunnySelected = hit2D.collider.gameObject;
                EvaluateSelection(bunnySelected);
            }
        }
    }

    private void EvaluateSelection(GameObject bunnySelected)
    {
        int result = problemsGenerator.GetResult();
        if (bunnySelected.transform.Find("Sign").transform.Find("Canvas").transform.Find("Number").gameObject.GetComponent<TextMeshProUGUI>().text == result.ToString())
        {
            audioController.PlayCorrectAnswer();
            CorrectSelection();
            timeController.SetTotalSeconds(1);
        }
        else
        {
            audioController.PlayIncorrectAnswer();
            IncorrectSelection();
            timeController.SetTotalSeconds(1);
        }
    }

    public void CorrectSelection()
    {
        levelController.ChangeLevel(true);
        levelController.ChangeScore(true);
    }

    public void IncorrectSelection()
    {
        levelController.ChangeLevel(false);
        levelController.ChangeScore(false);
    }
}
