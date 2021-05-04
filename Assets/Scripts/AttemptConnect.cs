using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptConnect : MonoBehaviour
{
    public bool tryConnect;

    public GameObject tryButton, stopButton, interfaces;

    // Start is called before the first frame update
    void Start()
    {
        AttemptToConnect();
    }

    public void AttemptToConnect()
    {
        tryConnect = true;
        tryButton.SetActive(false);
        stopButton.SetActive(true);
        interfaces.SetActive(true);
    }

    public void StopAttempt()
    {
        tryConnect = false;
        tryButton.SetActive(true);
        stopButton.SetActive(false);
        interfaces.SetActive(false);
    }
}
