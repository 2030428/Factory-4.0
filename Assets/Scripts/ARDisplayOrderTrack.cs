using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARDisplayOrderTrack : MonoBehaviour
{
    public cart cart;

    public Text ARDisplayText;

    public int machineNumber;


    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < cart.cartArray.Length; i++)
        {
            if (cart.cartArray[i].CarrierID == machineNumber && cart.cartArray[i].ONo >= 1000)
            {
                ARDisplayText.text = "Order number: " + cart.cartArray[i].ONo.ToString() + " is at this machine.";
            }
            else
            {
                ARDisplayText.text = "No order currently on this cart.";
            }
        }
    }
}
