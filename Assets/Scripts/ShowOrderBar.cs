using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrderBar : MonoBehaviour
{
    public Animator buttonBar, infoBar;             //refs to animators

    public GameObject showDisplay, hideDisplay;     //refs to game objects

    private void Start()
    {
        HideBars();                                 //calls functionat start
    }

    public void ShowBars()
    {
        buttonBar.SetBool("SwipeIn", true);         //sets animator bool true
        infoBar.SetBool("SwipeIn", true);           // ""
        showDisplay.SetActive(false);               //sets GO inactive
        hideDisplay.SetActive(true);                //sets GO active
    }

    public void HideBars()                          //same as above function, but opposite
    {
        buttonBar.SetBool("SwipeIn", false);
        infoBar.SetBool("SwipeIn", false);
        showDisplay.SetActive(true);
        hideDisplay.SetActive(false);
    }

}
