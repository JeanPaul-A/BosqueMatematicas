using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class BunniesController : MonoBehaviour
{
    [SerializeField] GameObject bunny;
    [SerializeField] ProblemsGenerator problemsGenerator;
    private struct BunnieColors
    {
        public Color bodyColor;
        public Color detailColor;
        public bool spawned;
    }

    private BunnieColors[] bunnieColors;
    private Vector3[] bunniePositions;
    private GameObject[] bunnies;

    void Start()
    {
        bunniePositions = new Vector3[5];
        bunnieColors = new BunnieColors[5];
        InitializePositons();
        InitializeColor();
        InstantiateBunnies();
    }

    private void InstantiateBunnies()
    {
        bunnies = new GameObject[5];

        for (int i = 0; i < 5; i++)
        {
            bunnies[i] = Instantiate(bunny, bunniePositions[i], Quaternion.identity);
            ColorizeBunnies(i);
        }

        problemsGenerator.SetBunniesSpawned(bunnies);
    }

    private void ColorizeBunnies(int i)
    {
        int colorBunny = 0;
        bool colorSelected = false;
        while (!colorSelected)
        {
            colorBunny = Mathf.RoundToInt(Random.Range(0, 5));
            colorSelected = !bunnieColors[colorBunny].spawned;
            bunnieColors[colorBunny].spawned = true;
        }
        bunnies[i].transform.Find("Body").gameObject.GetComponent<SpriteRenderer>().color = bunnieColors[colorBunny].bodyColor;
        bunnies[i].transform.Find("Details").gameObject.GetComponent<SpriteRenderer>().color = bunnieColors[colorBunny].detailColor;
    }

    

    public void RestartBunnies()
    {
        for (int i = 0; i < bunnies.Length; i++)
        {
            ColorizeBunnies(i);
        }
    }


    private void InitializeColor()
    {
        bunnieColors[0].bodyColor = new Color(175f / 255f, 1, 1, 1);
        bunnieColors[0].detailColor = new Color(200f / 255f, 1, 1, 1);

        bunnieColors[1].bodyColor = new Color(250f / 255f, 1, 175f / 255f, 1);
        bunnieColors[1].detailColor = new Color(250f / 255f, 1, 200f / 255f, 1); ;

        bunnieColors[2].bodyColor = new Color(1, 225f / 255f, 1, 1);
        bunnieColors[2].detailColor = new Color(1, 200f / 255f, 1, 1);

        bunnieColors[3].bodyColor = new Color(175f / 255f, 1, 175f / 255f, 1);
        bunnieColors[3].detailColor = new Color(150f / 255f, 225f / 255f, 150f / 255f, 1);

        bunnieColors[4].bodyColor = new Color(1, 175f / 255f, 175f / 255f, 1);
        bunnieColors[4].detailColor = new Color(1, 150f / 255f, 150f / 255f, 1);

        for (int i = 0; i < bunnieColors.Length; i++)
        {
            bunnieColors[i].spawned = false;
        }
    }

    private void InitializePositons()
    {
        for (int i = 0; i < bunniePositions.Length; i++)
        {
            bunniePositions[i] = new Vector3(-6f + (3 * i), -2.3f, 0f);
        }
    }
}
