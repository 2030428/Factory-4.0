using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class ResetEmergencyStopSubscribe : MonoBehaviour
{
    public OPCUA_Interface Interface;               //ref to interface script

    public string info;                             //creates string

    public int machineNumber;                       //creates int
        
    public bool needToReset;                        //creates bool

    private string active, inactive;                //creates private string


    // Start is called before the first frame update
    void Start()
    {
        Interface.EventOnConnected.AddListener(OnConnected);        //adds listener
        Interface.EventOnConnected.AddListener(OnDisconnected);     // ""
        Interface.EventOnConnected.AddListener(OnReconnect);        // ""

        active = "False";                           //sets string valule
        inactive = "True";                          // ""

    }

    // Update is called once per frame
    void Update()
    {
        if(info == active)                          //if these values are equal...
        {
            needToReset = false;                    //set bool false
        }

        if(info == inactive)                        //if these values are equal
        {
            needToReset = true;                     //set this bool true
        }
    }

    private void OnConnected()
    {
        //Debug.Log("Connected");                   //debug check
        var subscription = Interface.Subscribe("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xReset\"", NodeChanged);      //sets value to variable
        info = subscription.ToString();             //sets string value to var value
    }

    private void OnDisconnected()
    {
        //Debug.Log("Disconnected");                //debug check
    }

    private void OnReconnect()
    {
        //Debug.Log("Reconnecting");                //debug check
    }

    public void NodeChanged(OPCUANodeSubscription sub, object value)
    {        
        info = value.ToString();                            //sets string value
        //Debug.Log(sub.NodeId + " " + sub.StatusGood);     //debug check  
    }
}

