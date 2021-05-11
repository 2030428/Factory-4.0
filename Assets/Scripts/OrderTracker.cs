using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTracker : MonoBehaviour
{
    public RFIDReadDirectData RFIDData;

    public string orderInfo;

    public Text overlayOrderDisplay;

    private int orderCounter;
    private int[] orderNumber;

    private bool orderActive;

    private string firstRead, buildPallet, secondMachine, finalMachine;
    private string[] palletData;

    // Start is called before the first frame update
    void Start()
    {
        orderCounter = 0;
        orderInfo = "No build currently in progress.";
    }

    // Update is called once per frame
    void Update()
    {
        overlayOrderDisplay.text = orderInfo;

        if (orderActive)
        {            
            orderInfo = "Your order is initialising...";
            buildPallet = RFIDData.text1;

            if (firstRead != buildPallet)
            {
                string palletNumber = buildPallet.Substring(36);
                orderInfo = "Order number " + orderCounter + "is on pallet number " + palletNumber;
                if (palletData[1] == null)
                {
                    palletData[1] = palletNumber;
                    orderNumber[1] = orderCounter;
                    Debug.Log("Order number " + orderNumber[1] + " is on pallet number " + palletData[1]);
                }
                if (palletData[1] != null && palletData[2] == null)
                {
                    palletData[2] = palletNumber;
                    orderNumber[2] = orderCounter;
                    Debug.Log("Order number " + orderNumber[2] + " is on pallet number " + palletData[2]);
                }
                if (palletData[2] != null && palletData[3] == null)
                {
                    palletData[3] = palletNumber;
                    orderNumber[3] = orderCounter;
                    Debug.Log("Order number " + orderNumber[3] + " is on pallet number " + palletData[3]);
                }
                if (palletData[3] != null && palletData[4] == null)
                {
                    palletData[4] = palletNumber;
                    orderNumber[4] = orderCounter;
                    Debug.Log("Order number " + orderNumber[4] + " is on pallet number " + palletData[4]);
                }
            }

            CheckCompletion();

        }
    }

    public void TrackBuild()
    {        
        if (RFIDData.text1 == "." || RFIDData.text1 == "No connection to Machine 1.")
        {
            orderInfo = "No connection to machine, try again.";
        }
        else
        {
            orderCounter++;
            firstRead = RFIDData.text1;
            orderActive = true;
        }
    }

    public void CheckSecondMachine()
    {
        secondMachine = RFIDData.text2;
        string secondMachinePallet = secondMachine.Substring(36);

        for (int i = 0; i < palletData.Length; i++)
        {
            if (palletData[i] == secondMachinePallet)
            {
                orderInfo = "Pallet " + palletData[i] + " with order number " + orderNumber[i] + " is at the second machine.";
                Debug.Log("A recognised order is at machine 2");
            }
        }
    }

    public void CheckCompletion()
    {
        finalMachine = RFIDData.text9;
        string finalMachinePallet = finalMachine.Substring(36);

        for(int i = 0; i < palletData.Length; i++)
        {
            if(palletData[i] == finalMachinePallet)
            {
                orderInfo = "Pallet " + palletData[i] + " with order number " + orderNumber[i] + " is at the final machine.";
            }
        }
    }
}
