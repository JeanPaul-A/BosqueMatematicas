using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Vector2 backgroundSpeed;
    private Vector2 backgroundSpeedDefault;
    private Vector2 offset;
    private Material material;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        backgroundSpeedDefault = backgroundSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        offset = backgroundSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

    public void AlterBackgroundSpeed()
    {
        backgroundSpeed = (backgroundSpeed == backgroundSpeedDefault) ? new Vector2(0, 0) : backgroundSpeedDefault;
    }
}
