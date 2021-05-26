using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ARDisplayOrderTrack : MonoBehaviour
{
    public RFIDReaderSubscribe RFIDSub;             //ref to rfid subscribe script

    public cart cart;                               //ref to cart data script

    public Text ARDisplayText;                      //ref to text object

    public int machineNumber;                       //int for mchine number

    public string cartNumberAtStation, zero;              //string to store cart number info

    public string orderNumberAtStation;             //string to store order number info

    public TextMeshPro text;                        //ref to text mesh pro object

    public bool triggered;

    private void Start()
    {
        text.text = "";                             //sets text to blank
        triggered = false;
        zero = "0";
        cart.GetRequestPublic();
    }

    // Update is called once per frame
    void Update()
    {
        cartNumberAtStation = RFIDSub.info;         //sets string to value from rfid reader

        for(int i = 0; i < cart.cartArray.Length; i++)                                                              //for every object in array length....
        {
            if (!triggered)
            {
                if (cart.cartArray[i].CarrierID.ToString() == cartNumberAtStation)        //if cart number from json is same as cart number from rfid reader and order neumber over 1....
                {
                    orderNumberAtStation = cart.cartArray[i].ONo.ToString();                                            //set value to string
                    ARDisplayText.text = "Order number: " + orderNumberAtStation;                                         //set this text
                    text.text = orderNumberAtStation;
                    triggered = true;
                    //Debug.LogError(cart.cartArray[i].ONo.ToString());
                }
                else                                                                                                    //if not...
                {
                    ARDisplayText.text = "";
                    text.text = "";
                }
            }
            else
            {
                if (cart.cartArray[i].CarrierID.ToString() == cartNumberAtStation)        //if cart number from json is same as cart number from rfid reader and order neumber over 1....
                {
                    orderNumberAtStation = cart.cartArray[i].ONo.ToString();                                            //set value to string
                    ARDisplayText.text = "";              //set text value
                    text.text = "";                                                                   //set text value
                    triggered = true;
                    //Debug.LogError(cart.cartArray[i].ONo.ToString());
                }
                else                                                                                                    //if not...
                {
                    if(orderNumberAtStation != zero)
                    {
                        ARDisplayText.text = "Order number: " + orderNumberAtStation;                                         //set this text
                        text.text = orderNumberAtStation;
                    }
                    else
                    {
                        ARDisplayText.text = "";
                        text.text = "" ;
                    }                                                                //set this text
                }
            }
        }
    }
}
