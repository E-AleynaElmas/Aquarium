using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    public List<GameObject> grid_sqaures_ = new List<GameObject>();
    private int[] data = new int[36];
    public List<Text> column_texts = new List<Text>();
    public List<Text> row_texts = new List<Text>();

    public void SetSolution()
    {
        int square_index = 0;
        for (int row = 0; row < 6; row++)
        {
            for (int column = 0; column < 6; column++)
            {
                if (grid_sqaures_[square_index].GetComponent<GridSettings>().IsXActive())
                {
                    data[square_index] = 0;
                }
                else if (grid_sqaures_[square_index].GetComponent<GridSettings>().IsBubbleActive())
                {
                    data[square_index] = 1;
                }

                else
                    data[square_index] = 0;

                square_index++;
            }
        }
    }

    private void Update()
    {
        SetSolution();
        WrongForColumn();
        WrongForRow();
    }

    private void WrongForColumn()
    {
        int boundary = 0;
        for (int i = 0; i < 6; i++)
        {
            int counter = 0;
            for(int j = 0; j < 35; j=j+6)
            {
                if (data[i + j] == 1)
                {
                    counter++;
                }
            }
            boundary = int.Parse(column_texts[i].text);
            if(counter > boundary)
            {
                column_texts[i].color = Color.red;
            }
            else
            {
                column_texts[i].color = Color.white;
            }
        }
    }

    private void WrongForRow()
    {
        int bound = 0;
        int k = 0;
        for (int i = 0; i <= 30; i = i + 6)
        {
            int counter = 0;
            for (int j = 0; j < 6; j++)
            {
                if (data[i + j] == 1)
                {
                    counter++;
                }
            }
            bound = int.Parse(row_texts[k].text);
            if (counter > bound)
            {
                row_texts[k].color = Color.red;
            }
            else
            {
                row_texts[k].color = Color.white;
            }
            k++;
        }

    }

    /*public void Control()
    {
        for (int i = 0; i < 36; i++)
        {
            if (data[i] != realSolution[i])
            {
                Debug.Log("yenildin :(");
                return;
            }
        }
        Debug.Log("tebrikler!");
    }*/

    public int[] getData()
    {
        return data;
    }
}

