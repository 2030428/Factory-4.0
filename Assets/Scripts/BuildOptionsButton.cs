using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOptionsButton : MonoBehaviour
{
    public Animator buttonBar;

    public GameObject showDisplay, hideDisplay;


    // Start is called before the first frame update
    void Start()
    {
        HideBar();
    }

    public void ShowBar()
    {
        buttonBar.SetBool("SwipeIn", true);
        showDisplay.SetActive(false);
        hideDisplay.SetActive(true);
    }

    public void HideBar()
    {
        buttonBar.SetBool("SwipeIn", false);
        showDisplay.SetActive(true);
        hideDisplay.SetActive(false);
    }
}
