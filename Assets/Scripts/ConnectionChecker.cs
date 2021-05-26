using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;


public class ConnectionChecker : MonoBehaviour
{
    public OPCUA_Interface[] interfaces;                //ref for the array of interfaces

    public bool connected, allConnected;                //creates bools


    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <interfaces.Length; i++)       //for each interface in the array...       
        {
            if(interfaces[i].IsConnected)               //if connected...
            {
                allConnected = true;                    //set bool true
            }
            else                                        //if not...
            {
                allConnected = false;                   //set bool false
            }
        }
    }
}
