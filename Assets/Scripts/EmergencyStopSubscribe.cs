using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class EmergencyStopSubscribe : MonoBehaviour
{
    public OPCUA_Interface Interface;

    public GameObject idle, good, emergency, emgSphere;

    public string info;

    public int machineNumber;

    public bool triggered;

    private string active, inactive;

    public Material noEmg, emgActive, noConnection;

    public Animator sphereAnimate;


    // Start is called before the first frame update
    void Start()
    {
        Interface.EventOnConnected.AddListener(OnConnected);
        Interface.EventOnConnected.AddListener(OnDisconnected);
        Interface.EventOnConnected.AddListener(OnReconnect);

        active = "False";
        inactive = "True";

        emgSphere.GetComponent<MeshRenderer>().material = noConnection;

        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (info == null)
        {
            idle.SetActive(true);
            emergency.SetActive(false);
            good.SetActive(false);
            NoConnection();
        }

        if (info == active)
        {
            triggered = true;
            emergency.SetActive(true);
            idle.SetActive(false);
            good.SetActive(false);
            EmergencySphereActive();
            triggered = true;
        }

        if (info == inactive)
        {
            good.SetActive(true);
            idle.SetActive(false);
            emergency.SetActive(false);
            EmergencySphereInactive();
            triggered = false;
        }
    }

    private void OnConnected()
    {
        Debug.Log("Connected");
        var subscription = Interface.Subscribe("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"", NodeChanged);
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

    public void EmergencySphereActive()
    {
        emgSphere.GetComponent<MeshRenderer>().material = emgActive;
        sphereAnimate.SetBool("Emergency", true);
    }

    public void EmergencySphereInactive()
    {
        emgSphere.GetComponent<MeshRenderer>().material = noEmg;
        sphereAnimate.SetBool("Emergency", false);
    }

    public void NoConnection()
    {
        emgSphere.GetComponent<MeshRenderer>().material = noConnection;
        sphereAnimate.SetBool("Emergency", false);
    }
}

