using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GridSettings : Selectable, IPointerClickHandler
{
    public GameObject red_x;
    public GameObject water_bubble;
    private bool active_x;
    private bool active_bubble;
    private bool empty=true;
    public int square_index_ = -1;

    public int GetIndex()
    {
        return square_index_;
    }

    public void SetSquareIndex(int index)
    {
        square_index_ = index;
    }

    public bool IsXActive()
    {
        return active_x == true;
    }

    private void SetActiveX()
    {
        water_bubble.SetActive(false);
        active_bubble = false;
        red_x.SetActive(true);
        active_x = true;
        active_bubble = false;
        empty = false;
        
    }

    public bool IsBubbleActive()
    {
        return active_bubble == true;
    }

    private void SetActiveBubble()
    {
        water_bubble.SetActive(true);
        active_bubble = true;
        empty = false;
        active_x = false;
    }

    public bool IsEmpty()
    {
        return empty == true;
    }

    private void SetEmpty()
    {
        red_x.SetActive(false);
        active_x = false;
        active_bubble = false;
        empty = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsEmpty())
        {
            SetActiveBubble();
        }
        else if (IsBubbleActive())
        {
            SetActiveX();
        }
        else
            SetEmpty();
     
    }
}
