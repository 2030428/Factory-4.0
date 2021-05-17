using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class ResetEmergencyStopSubscribe : MonoBehaviour
{
    public OPCUA_Interface Interface;

    public string info;

    public int machineNumber;

    public bool needToReset;

    private string active, inactive;


    // Start is called before the first frame update
    void Start()
    {
        Interface.EventOnConnected.AddListener(OnConnected);
        Interface.EventOnConnected.AddListener(OnDisconnected);
        Interface.EventOnConnected.AddListener(OnReconnect);

        active = "False";
        inactive = "True";

    }

    // Update is called once per frame
    void Update()
    {
        if(info == active)
        {
            needToReset = false;
        }

        if(info == inactive)
        {
            needToReset = true;
        }
    }

    private void OnConnected()
    {
        Debug.Log("Connected");
        var subscription = Interface.Subscribe("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xReset\"", NodeChanged);
        info = subscription.ToString();
    }

    private void OnDisconnected()
    {
        Debug.Log("Disconnected");
    }

    private void OnReconnect()
    {
        Debug.Log("Reconnecting");
    }

    public void NodeChanged(OPCUANodeSubscription sub, object value)
    {        
        info = value.ToString();
        Debug.Log(sub.NodeId + " " + sub.StatusGood);        
    }
}

