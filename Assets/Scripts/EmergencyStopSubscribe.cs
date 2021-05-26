using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class EmergencyStopSubscribe : MonoBehaviour
{
    public OPCUA_Interface Interface;                       //ref to interface script

    public GameObject idle, good, emergency, emgSphere;     //refs to game objects

    public string info;                                     //creates string

    public int machineNumber;                               //creates int

    public bool triggered;                                  //creates bool

    private string active, inactive;                        //creats private strings

    public Material noEmg, emgActive, noConnection;         //refs to materials

    public Animator sphereAnimate;                          //ref to animator


    // Start is called before the first frame update
    void Start()
    {
        Interface.EventOnConnected.AddListener(OnConnected);        //adds listener
        Interface.EventOnConnected.AddListener(OnDisconnected);     // ""
        Interface.EventOnConnected.AddListener(OnReconnect);        // ""

        active = "False";                                           //sets string value
        inactive = "True";                                          // ""

        emgSphere.GetComponent<MeshRenderer>().material = noConnection;     //sets material of object

        triggered = false;                                          //sets bool
    }

    // Update is called once per frame
    void Update()
    {
        if (info == null)                               //if these values equal....
        {
            idle.SetActive(true);                       //set active
            emergency.SetActive(false);                 //set inactive
            good.SetActive(false);                      // ""
            NoConnection();                             //call function
        }

        if (info == active)                             //if these values are equal....
        {
            triggered = true;                           //set bool true
            emergency.SetActive(true);                  //set active
            idle.SetActive(false);                      //set inactive
            good.SetActive(false);                      // ""
            EmergencySphereActive();                    //call function
        }

        if (info == inactive)                           //if these values are equal....
        {
            good.SetActive(true);                       //set active
            idle.SetActive(false);                      //set inactive
            emergency.SetActive(false);                 // ""
            EmergencySphereInactive();                  //call this function
            triggered = false;                          //set bool false
        }
    }

    private void OnConnected()
    {
        //Debug.Log("Connected");                       //debug check
        var subscription = Interface.Subscribe("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"", NodeChanged);     //gets value when there is change
        info = subscription.ToString();                 //sets value to string
    }

    private void OnDisconnected()
    {
        //Debug.Log("Disconnected");                    //debug check
    }

    private void OnReconnect()
    {
        //Debug.Log("Reconnecting");                    //debug check
    }

    public void NodeChanged(OPCUANodeSubscription sub, object value)
    {
        info = value.ToString();                            //sets value to string
        //Debug.Log(sub.NodeId + " " + sub.StatusGood);     //debug check
    }

    public void EmergencySphereActive()
    {
        emgSphere.GetComponent<MeshRenderer>().material = emgActive;    //sets material for object
        sphereAnimate.SetBool("Emergency", true);                       //sets animator bool true
    }

    public void EmergencySphereInactive()
    {
        emgSphere.GetComponent<MeshRenderer>().material = noEmg;        //sets material for object
        sphereAnimate.SetBool("Emergency", false);                      //sets animator bool false
    }

    public void NoConnection()
    {
        emgSphere.GetComponent<MeshRenderer>().material = noConnection; //sets material for object
        sphereAnimate.SetBool("Emergency", false);                      //sets animator bool false
    }
}

