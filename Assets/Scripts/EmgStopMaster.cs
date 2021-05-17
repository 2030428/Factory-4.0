using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmgStopMaster : MonoBehaviour
{
    public int stoppedMachine, arrayNumber;

    public GameObject overlayGood, overlayEmergency;

    public Text displayText;

    public EmergencyStopSubscribe[] emergencyStopCheckers;

    public ResetEmergencyStopSubscribe[] resetCheckers;

    public bool triggered;

    
    // Start is called before the first frame update
    void Start()
    {
        NoEmergency();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            if (emergencyStopCheckers[arrayNumber].triggered && !resetCheckers[arrayNumber].needToReset)
            {
                ActiveEmergency();
            }

            if (!emergencyStopCheckers[arrayNumber].triggered && !resetCheckers[arrayNumber].needToReset)
            {
                ActiveEmergency();
            }
            if (!emergencyStopCheckers[arrayNumber].triggered && resetCheckers[arrayNumber].needToReset)
            {
                NoEmergency();
                triggered = false;
            }
        }

        for (int i = 0; i < emergencyStopCheckers.Length; i++)
        {
            if (emergencyStopCheckers[i].triggered && !triggered)
            {
                triggered = true;
                arrayNumber = i;
                stoppedMachine = (i + 1);
                ActiveEmergency();
            }
        }
    }

    public void NoEmergency()
    {
        overlayGood.SetActive(true);
        overlayEmergency.SetActive(false);
        displayText.text = "No emergency";

        for (int i = 0; i < emergencyStopCheckers.Length; i++)
        {
            emergencyStopCheckers[i].EmergencySphereInactive();
        }

    }

    public void ActiveEmergency()
    {
        overlayGood.SetActive(false);
        overlayEmergency.SetActive(true);
        displayText.text = "Check emergency on machine " + stoppedMachine + "!";
        emergencyStopCheckers[arrayNumber].EmergencySphereActive();
    }
}
