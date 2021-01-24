using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public List<GameObject> easy_levels = new List<GameObject>();
    public List<GameObject> hard_levels = new List<GameObject>();
    private int[] data = new int[36];
    private int count = 0;
    private string level;
    public GameObject winpopup;
    public GameObject gameoverpopup;

    private int[] Easy_Level1 = new int[36]
    {
        1, 1, 1, 1, 1, 0,
        1, 1, 0, 0, 1, 1,
        1, 0, 0, 1, 1, 0,
        1, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 1, 0,
        1, 1, 1, 1, 0, 0
    };

    private int[] Easy_Level2 = new int[36]
    {
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        0, 0, 0, 1, 1, 1,
        1, 0, 0, 1, 0, 1,
        1, 0, 0, 0, 0, 1
    };

    private int[] Easy_Level3 = new int[36]
    {
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 1, 1, 0,
        0, 0, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 1,
        0, 1, 0, 1, 1, 1,
        0, 0, 0, 1, 1, 1
    };

    private int[] Easy_Level4 = new int[36]
    {
        0, 0, 0, 0, 1, 1,
        0, 0, 0, 1, 1, 1,
        0, 0, 0, 1, 1, 1,
        1, 1, 0, 0, 0, 0,
        1, 1, 1, 0, 0, 0,
        1, 1, 1, 0, 0, 0
    };

    private int[] Easy_Level5 = new int[36]
    {
        0, 0, 0, 1, 1, 1,
        1, 0, 0, 0, 1, 0,
        0, 0, 1, 0, 0, 0,
        0, 1, 1, 1, 1, 1,
        0, 1, 1, 1, 1, 1,
        0, 0, 0, 1, 1, 1
    };

    private int[] Hard_Level1 = new int[36]
    {
        1, 1, 0, 0, 0, 0,
        0, 0, 1, 0, 0, 0,
        1, 1, 1, 1, 1, 0,
        1, 1, 1, 1, 0, 0,
        1, 1, 0, 1, 1, 1,
        1, 1, 0, 1, 1, 1
    };

    private int[] Hard_Level2 = new int[36]
    {
        0, 0, 0, 0, 1, 1,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 1, 1, 1,
        0, 1, 0, 1, 1, 1,
        1, 1, 0, 0, 0, 0
    };

    private int[] Hard_Level3 = new int[36]
    {
        0, 0, 1, 0, 0, 0,
        0, 0, 0, 0, 0, 1,
        0, 1, 0, 1, 1, 1,
        0, 0, 0, 1, 0, 1,
        0, 1, 0, 0, 1, 1,
        1, 0, 0, 0, 0, 0
    };

    private int[] Hard_Level4 = new int[36]
    {
        1, 1, 0, 1, 1, 1,
        1, 1, 1, 0, 0, 1,
        1, 1, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 1,
        1, 1, 1, 1, 0, 0,
        1, 1, 1, 0, 0, 1
    };

    private int[] Hard_Level5 = new int[36]
    {
        1, 1, 1, 1, 0, 0,
        1, 1, 0, 1, 1, 1,
        1, 1, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        1, 1, 0, 1, 1, 0,
        1, 1, 0, 0, 0, 1
    };

    private List<int[]> easy_solutions = new List<int[]>();
    private List<int[]> hard_solutions = new List<int[]>();

    private void SetSolutions()
    {
        easy_solutions.Add(Easy_Level1);
        easy_solutions.Add(Easy_Level2);
        easy_solutions.Add(Easy_Level3);
        easy_solutions.Add(Easy_Level4);
        easy_solutions.Add(Easy_Level5);
        hard_solutions.Add(Hard_Level1);
        hard_solutions.Add(Hard_Level2);
        hard_solutions.Add(Hard_Level3);
        hard_solutions.Add(Hard_Level4);
        hard_solutions.Add(Hard_Level5);
    }

    private void Start()
    {
        SetSolutions();
    }

    public void StartEasy()
    {
        count = Random.Range(0, easy_levels.Count);
        easy_levels[count].SetActive(true);
        level = "easy";
    }

    public void StartHard()
    {
        count = Random.Range(0,hard_levels.Count);
        hard_levels[count].SetActive(true);
        level = "hard";
    }

    public void Control()
    {
        data = GameObject.Find("GridSquare").GetComponent<GridSquare>().getData();
        if (level == "easy")
        {
            for (int i = 0; i < 36; i++)
            {
                if (data[i] != easy_solutions[count][i])
                {
                    Clock.instance.SetStopClock(true);
                    gameoverpopup.SetActive(true);
                    return;
                }
            }
            Clock.instance.SetStopClock(true);
            winpopup.SetActive(true);
        }
        else
        {
            for (int i = 0; i < 36; i++)
            {
                if (data[i] != hard_solutions[count][i])
                {
                    Clock.instance.SetStopClock(true);
                    gameoverpopup.SetActive(true);
                    return;
                }
            }
            Clock.instance.SetStopClock(true);
            winpopup.SetActive(true);
        }
        
    }

}
