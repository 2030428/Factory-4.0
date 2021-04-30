using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class RFIDReadDirectData : MonoBehaviour
{
    public Text FM1, FM2, FM3, FM4, FM5, FM6, FM7, FM8, FM9;

    public OPCUA_Interface Interface1, Interface2, Interface3, Interface4, Interface5, Interface6, Interface7, Interface8, Interface9;

    private string text1, text2, text3, text4, text5, text6, text7, text8, text9;

    // Start is called before the first frame update
    void Start()
    {
        FM1.text = ("Awaiting connection to Machine 1...");
        FM2.text = ("Awaiting connection to Machine 2...");
        FM3.text = ("Awaiting connection to Machine 3...");
        FM4.text = ("Awaiting connection to Machine 4...");
        FM5.text = ("Awaiting connection to Machine 5...");
        FM6.text = ("Awaiting connection to Machine 6...");
        FM7.text = ("Awaiting connection to Machine 7...");
        FM8.text = ("Awaiting connection to Machine 8...");
        FM9.text = ("Awaiting connection to Machine 9...");
    }

    // Update is called once per frame
    void Update()
    {
        var ONE = Interface1.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text1 = ("RFID tag at machine 1 is ") + ONE.ToString();
        FM1.text = text1;
        if(ONE == null)
        {
            FM1.text = ("No reading RFID machine 1");
        }

        var TWO = Interface2.ReadNodeValue("ns = 3; s = \"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text2 = ("RFID tag at machine 2 is ") + TWO.ToString();
        FM2.text = text2;
        if (TWO == null)
        {
            FM2.text = ("No reading RFID machine 2");
        }

        var THREE = Interface3.ReadNodeValue("ns = 3; s = \"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text3 = ("RFID tag at machine 3 is ") + THREE.ToString();
        FM3.text = text3;
        if (THREE == null)
        {
            FM3.text = ("No reading RFID machine 3");
        }

        var FOUR = Interface4.ReadNodeValue("ns = 3; s = \"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text4 = ("RFID tag at machine 4 is ") + FOUR.ToString();
        FM4.text = text4;
        if (FOUR == null)
        {
            FM4.text = ("No reading RFID machine 4");
        }

        var FIVE = Interface5.ReadNodeValue("ns = 3; s = \"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text5 = ("RFID tag at machine 5 is ") + FIVE.ToString();
        FM5.text = text5;
        if (FIVE == null)
        {
            FM5.text = ("No reading RFID machine 5");
        }

        var SIX = Interface6.ReadNodeValue("ns = 3; s = \"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text6 = ("RFID tag at machine 6 is ") + SIX.ToString();
        FM6.text = text6;
        if (SIX == null)
        {
            FM6.text = ("No reading RFID machine 6");
        }

        var SEVEN = Interface7.ReadNodeValue("ns = 3; s = \"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text7 = ("RFID tag at machine 7 is ") + SEVEN.ToString();
        FM7.text = text7;
        if (SEVEN == null)
        {
            FM7.text = ("No reading RFID machine 7");
        }

        var EIGHT = Interface8.ReadNodeValue("ns = 3; s = \"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text8 = ("RFID tag at machine 8 is ") + EIGHT.ToString();
        FM8.text = text8;
        if (EIGHT == null)
        {
            FM8.text = ("No reading RFID machine 8");
        }

        var NINE = Interface9.ReadNodeValue("ns = 3; s = \"dbRfidData\".\"ID1\".\"iCarrierID\"");
        text9 = ("RFID tag at machine 9 is ") + NINE.ToString();
        FM9.text = text9;
        if (NINE == null)
        {
            FM9.text = ("No reading RFID machine 9");
        }
    }
}
