using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

//*******SCRIPT NOT USED********

public class RFIDReaderSubscribeMultiple : MonoBehaviour
{
    public OPCUA_Interface Interface1, Interface2, Interface3, Interface4, Interface5, Interface6, Interface7, Interface8, Interface9;

    public Text FM1, FM2, FM3, FM4, FM5, FM6, FM7, FM8, FM9;

    public string info1, info2, info3, info4, info5, info6, info7, info8, info9, factoryMachine;


    // Start is called before the first frame update
    void Start()
    {
        Interface1.EventOnConnected.AddListener(OnConnected1);
        Interface1.EventOnConnected.AddListener(OnDisconnected1);
        Interface1.EventOnConnected.AddListener(OnReconnect1);

        Interface2.EventOnConnected.AddListener(OnConnected2);
        Interface2.EventOnConnected.AddListener(OnDisconnected2);
        Interface2.EventOnConnected.AddListener(OnReconnect2);
    }

    // Update is called once per frame
    void Update()
    {
        FM1.text = factoryMachine + " last saw RFID tag " + info1;
        FM2.text = factoryMachine + " last saw RFID tag " + info2;

    }

    private void OnConnected1()
    {
        Debug.Log("Connected");
        var subscription1 = Interface5.Subscribe1("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"", NodeChanged1);
        info1 = subscription1.ToString();
    }

    private void OnDisconnected1()
    {
        Debug.Log("Disconnected");
    }

    private void OnReconnect1()
    {
        Debug.Log("Reconnecting");
    }

    public void NodeChanged1(OPCUANodeSubscription sub1, object value1)
    {        
        info1 = value1.ToString();
        Debug.Log(sub1.ServerSubscription.Client.ServerAddress.ToString() + " " + sub1.NodeId + " " + sub1.StatusGood);        
    }



    private void OnConnected2()
    {
        Debug.Log("Connected");
        var subscription2 = Interface6.Subscribe2("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"", NodeChanged2);
        info2 = subscription2.ToString();
    }

    private void OnDisconnected2()
    {
        Debug.Log("Disconnected");
    }

    private void OnReconnect2()
    {
        Debug.Log("Reconnecting");
    }

    public void NodeChanged2(OPCUANodeSubscription sub2, object value2)
    {        
        info2 = value2.ToString();
        Debug.Log(sub2.ServerSubscription.Client.ServerAddress.ToString() + " " + sub2.NodeId + " " + sub2.StatusGood);        
    }
}
