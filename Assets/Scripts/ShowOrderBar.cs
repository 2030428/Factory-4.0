using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrderBar : MonoBehaviour
{
    public Animator buttonBar, infoBar;

    public GameObject showDisplay, hideDisplay;

    private void Start()
    {
        HideBars();
    }

    public void ShowBars()
    {
        buttonBar.SetBool("SwipeIn", true);
        infoBar.SetBool("SwipeIn", true);
        showDisplay.SetActive(false);
        hideDisplay.SetActive(true);
    }

    public void HideBars()
    {
        buttonBar.SetBool("SwipeIn", false);
        infoBar.SetBool("SwipeIn", false);
        showDisplay.SetActive(true);
        hideDisplay.SetActive(false);
    }

}
