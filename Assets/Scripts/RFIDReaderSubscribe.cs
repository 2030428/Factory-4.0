using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;
using TMPro;

public class RFIDReaderSubscribe : MonoBehaviour
{
    public OPCUA_Interface Interface;               //ref to innterface script

    public Text FM;                                 //ref to text object

    public TextMeshPro text;                        //ref to text mesh pro object

    public string info, factoryMachine;             //creates strings


    // Start is called before the first frame update
    void Start()
    {
        Interface.EventOnConnected.AddListener(OnConnected);        //adds listener
        Interface.EventOnConnected.AddListener(OnDisconnected);     // ""
        Interface.EventOnConnected.AddListener(OnReconnect);        // ""
    }

    // Update is called once per frame
    void Update()
    {
        FM.text = factoryMachine + " last saw RFID tag " + info;    //sets text value
        text.text = info;                                           //sets TMPro value
    }

    private void OnConnected()
    {
        //Debug.Log("Connected");                                   //debug check
        var subscription = Interface.Subscribe("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"", NodeChanged);    //sets value to variable
        info = subscription.ToString();                             //sets string to variable value
    }

    private void OnDisconnected()
    {
        //Debug.Log("Disconnected");                                //debug check
    }

    private void OnReconnect()
    {
        //Debug.Log("Reconnecting");                                //debug check
    }

    public void NodeChanged(OPCUANodeSubscription sub, object value)
    {        
        info = value.ToString();                                    //sets string value
        //Debug.Log(sub.NodeId + " " + sub.StatusGood);             //debug check
    }    
}
