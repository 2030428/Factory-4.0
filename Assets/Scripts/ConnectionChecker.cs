using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;


public class ConnectionChecker : MonoBehaviour
{
    public ConnectionChecker[] interfaces;

    public bool connected, allConnected;


    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <interfaces.Length; i++)
        {
            if(interfaces[i].connected)
            {
                allConnected = true;
            }
            else
            {
                allConnected = false;
            }
        }
    }

    public void Connected()
    {
        connected = true;
    }

    public void Disconeccted()
    {
        connected = false;
    }

}
