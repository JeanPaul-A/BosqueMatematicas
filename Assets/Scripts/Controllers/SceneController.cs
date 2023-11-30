using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void BtnPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BtnQuit()
    {
        Application.Quit();
    }

    public void BtnReturn()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
