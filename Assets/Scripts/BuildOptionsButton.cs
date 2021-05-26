using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOptionsButton : MonoBehaviour
{
    public Animator buttonBar;                              //ref to animator

    public GameObject showDisplay, hideDisplay;             //refs to game objects


    // Start is called before the first frame update
    void Start()
    {
        HideBar();                                      //calls this function at start
    }

    public void ShowBar()
    {
        buttonBar.SetBool("SwipeIn", true);             //sets animation bool true
        showDisplay.SetActive(false);                   //turns off GO
        hideDisplay.SetActive(true);                    //turns on GO
    }

    public void HideBar()
    {
        buttonBar.SetBool("SwipeIn", false);            //sets animation bool false
        showDisplay.SetActive(true);                    //turns on GO
        hideDisplay.SetActive(false);                   //turns off GO
    }
}
