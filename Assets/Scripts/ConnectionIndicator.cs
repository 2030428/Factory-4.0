using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionIndicator : MonoBehaviour
{
    public ConnectionChecker allConnected;          //ref to connection checker script

    public AttemptConnect tryingToConnect;          //ref to connection attempt script

    public GameObject connected, disconnected;      //refs to game objects

    // Update is called once per frame
    void Update()
    {
        if (tryingToConnect.tryConnect)             //if this bool true....
        {
            if (allConnected.allConnected)          //and this bool true....
            {
                connected.SetActive(true);          //set GO active
                disconnected.SetActive(false);      //set GO inactive
            }
        }
        if (!tryingToConnect.tryConnect)            //if bool false....
        {
            connected.SetActive(false);             //set GO inactive
            disconnected.SetActive(true);           //set GO active
        }
        if (!allConnected.allConnected)             //if this bool false....
        {
            connected.SetActive(false);             //set this GO inactive
            disconnected.SetActive(true);           //set this GO active
        }
    }
}
