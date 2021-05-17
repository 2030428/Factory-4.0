using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTracker : MonoBehaviour
{
    public RFIDReaderSubscribe[] RFIDData;
    public ConnectionChecker connection;
    public BuildPhone buildData;

    public string orderInfo;

    public Text overlayOrderDisplay;

    private int orderCounter;
    private int[] orderNumber;

    private bool orderActive;

    private string firstRead, buildPallet, secondMachine, finalMachine;
    private string[] palletData;
    public string machineOrderNumber;

    // Start is called before the first frame update
    void Start()
    {
        orderCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        overlayOrderDisplay.text = orderInfo;

        if (connection.connected && !orderActive)
        {
            orderInfo = "Connected to machine, awaiting order.";
        }
        if (!connection.connected)
        {
            orderInfo = "Not currently connected to machine."; ;
        }

        if (orderActive)
        {            
            machineOrderNumber = buildData.orderNumber.Substring(64, 67);
            Debug.LogError(machineOrderNumber);
            StartCoroutine(DelayRead());

            //CheckCompletion();
        }
    }

    public void TrackBuild()
    {        
        if (!connection.connected)
        {
            orderInfo = "No connection to machine, try again.";
        }
        if(connection.connected)
        {
            orderCounter++;
            firstRead = RFIDData[0].info;
            orderActive = true;
        }
    }

    public IEnumerator DelayRead()
    {
        orderInfo = "Your order is initialising...";
        yield return new WaitForSeconds(5f);
        buildPallet = RFIDData[0].info;
        orderInfo = "Your order is number " + machineOrderNumber + " and is on pallet " + buildPallet;
    }

    //public void CheckSecondMachine()
    //{
    //    secondMachine = RFIDData[1].info;

    //    for (int i = 0; i < palletData.Length; i++)
    //    {
    //        if (palletData[i] == secondMachine)
    //        {
    //            orderInfo = "Pallet " + palletData[i] + " with order number " + orderNumber[i] + " is at the second machine.";
    //            Debug.Log("A recognised order is at machine 2");
    //        }
    //    }
    //}

    //public void CheckCompletion()
    //{
    //    finalMachine = RFIDData[8].info;

    //    for (int i = 0; i < palletData.Length; i++)
    //    {
    //        if (palletData[i] == finalMachine)
    //        {
    //            orderInfo = "Pallet " + palletData[i] + " with order number " + orderNumber[i] + " is at the final machine.";
    //        }
    //    }
    //}
}
