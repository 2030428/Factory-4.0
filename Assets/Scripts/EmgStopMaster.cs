using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmgStopMaster : MonoBehaviour
{
    public int stoppedMachine, arrayNumber;                     //creates ints

    public GameObject overlayGood, overlayEmergency;            //refs to game objects

    public Text displayText;                                    //ref to text object

    public EmergencyStopSubscribe[] emergencyStopCheckers;      //ref to array of emergency stop checks

    public ResetEmergencyStopSubscribe[] resetCheckers;         //ref to array of reset buttton checks

    public bool triggered;                                      //creates bool

    
    // Start is called before the first frame update
    void Start()
    {
        NoEmergency();                                          //calls function at start
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)                                          //if true....
        {
            if (emergencyStopCheckers[arrayNumber].triggered && !resetCheckers[arrayNumber].needToReset)        //if emergency stop trggered on a machine and reset not done...
            {
                ActiveEmergency();                                                                              //emergency active, call function
            }

            if (!emergencyStopCheckers[arrayNumber].triggered && !resetCheckers[arrayNumber].needToReset)       //if emg stop not triggered, but reset not done....
            {
                ActiveEmergency();                                                                              //emergency active, call function
            }
            if (!emergencyStopCheckers[arrayNumber].triggered && resetCheckers[arrayNumber].needToReset)        //if emg stop not triggered and reset has been done/....
            {
                NoEmergency();                                                                                  //emergency over, call function
                triggered = false;                                                                              //set bool false
            }
        }

        for (int i = 0; i < emergencyStopCheckers.Length; i++)              //for each emgstopchecker in array...
        {
            if (emergencyStopCheckers[i].triggered && !triggered)           //if any in array have bool triggered and trggered is false....
            {
                triggered = true;                                           //set to true
                arrayNumber = i;                                            //sets int value
                stoppedMachine = (i + 1);                                   //set int value
                ActiveEmergency();                                          //call function
            }
        }
    }

    public void NoEmergency()
    {
        overlayGood.SetActive(true);                                        //set GO active
        overlayEmergency.SetActive(false);                                  //set GO inactive
        displayText.text = "No emergency";                                  //sets text value

        for (int i = 0; i < emergencyStopCheckers.Length; i++)              //for each emgstopchecker in array length....
        {
            emergencyStopCheckers[i].EmergencySphereInactive();             //call this function
        }

    }

    public void ActiveEmergency()
    {
        overlayGood.SetActive(false);                                               //set this GO inactive
        overlayEmergency.SetActive(true);                                           //set this GO active
        displayText.text = "Check emergency on machine " + stoppedMachine + "!";    //set text value
        emergencyStopCheckers[arrayNumber].EmergencySphereActive();                 //set this function active for specific checker in array
    }
}
