using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptConnect : MonoBehaviour
{
    public bool tryConnect;                                     //creates bool

    public GameObject tryButton, stopButton, interfaces;        //refs to game objects

    // Start is called before the first frame update
    void Start()
    {
        AttemptToConnect();                                     //calls this functionat start
    }

    public void AttemptToConnect()
    {
        tryConnect = true;                          //sets bool true
        tryButton.SetActive(false);                 //turns off GO
        stopButton.SetActive(true);                 //turns on GO
        interfaces.SetActive(true);                 //turns on GO
    }

    public void StopAttempt()
    {
        tryConnect = false;                         //sets bool false
        tryButton.SetActive(true);                  //turns on GO
        stopButton.SetActive(false);                //turns off GO
        interfaces.SetActive(false);                //turns off GO
    }
}
