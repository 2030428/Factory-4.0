using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionIndicator : MonoBehaviour
{
    public ConnectionChecker allConnected;

    public AttemptConnect tryingToConnect;

    public GameObject connected, disconnected;

    // Update is called once per frame
    void Update()
    {
        if (tryingToConnect.tryConnect)
        {
            if (allConnected.allConnected)
            {
                connected.SetActive(true);
                disconnected.SetActive(false);
            }
        }
        if (!tryingToConnect.tryConnect)
        {
            connected.SetActive(false);
            disconnected.SetActive(true);
        }
        if (!allConnected.allConnected)
        {
            connected.SetActive(false);
            disconnected.SetActive(true);
        }
    }
}
