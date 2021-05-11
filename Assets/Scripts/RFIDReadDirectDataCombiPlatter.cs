using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class RFIDReadDirectDataCombiPlatter : MonoBehaviour
{
    public AttemptConnect tryToConnect;

    public Text FM1, FM2, FM3, FM4, FM5, FM6, FM7, FM8, FM9;

    public OPCUA_Interface Interface1, Interface2, Interface3, Interface4, Interface5, Interface6, Interface7, Interface8, Interface9;

    private string text1, text2, text3, text4, text5, text6, text7, text8, text9;

    private bool changeText;

    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForChange();

    }

    public void CheckForChange()
    {
        var ONE = Interface1.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (ONE == null)
        {
            FM1.text = ("No reading RFID machine 1");
        }
        else
        {
            text1 = ("The last RFID tag at machine 1 was ") + ONE.ToString();
            FM1.text = text1;
        }
  

        var TWO = Interface2.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (TWO == null)
        {
            FM2.text = ("No reading RFID machine 2");
        }
        else
        {
            text2 = ("The last RFID tag at machine 2 was ") + TWO.ToString();
            FM2.text = text2;
        }
        
    }

}
