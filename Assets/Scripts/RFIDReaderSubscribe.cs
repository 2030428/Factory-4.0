using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class RFIDReaderSubscribe : MonoBehaviour
{
    public OPCUA_Interface Interface;

    public Text FM;

    public string info, factoryMachine;


    // Start is called before the first frame update
    void Start()
    {
        Interface.EventOnConnected.AddListener(OnConnected);
        Interface.EventOnConnected.AddListener(OnDisconnected);
        Interface.EventOnConnected.AddListener(OnReconnect);
    }

    // Update is called once per frame
    void Update()
    {
        FM.text = factoryMachine + " last saw RFID tag " + info;
    }

    private void OnConnected()
    {
        Debug.Log("Connected");
        var subscription = Interface.Subscribe("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"", NodeChanged);
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
        if(Interface.tag == factoryMachine)
        {
            info = value.ToString();
            Debug.Log(sub.NodeId + " " + sub.StatusGood);
        }
    }    
}
