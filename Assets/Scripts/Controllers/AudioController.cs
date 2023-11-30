using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip menuScene;
    [SerializeField] private AudioClip gameScene;
    [SerializeField] private AudioClip correctAnswer;
    [SerializeField] private AudioClip incorrectAnswer;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = transform.Find("SourceExtra").GetComponent<AudioSource>();
    }

    public void PlayCorrectAnswer()
    {
        audioSource.clip = correctAnswer;
        audioSource.Play();
    }

    public void PlayIncorrectAnswer()
    {
        audioSource.clip = incorrectAnswer;
        audioSource.Play();
    }
}
