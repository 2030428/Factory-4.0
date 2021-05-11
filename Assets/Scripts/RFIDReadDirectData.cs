using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class RFIDReadDirectData : MonoBehaviour
{
    public AttemptConnect tryToConnect;

    public Text FM1, FM2, FM3, FM4, FM5, FM6, FM7, FM8, FM9;

    public OPCUA_Interface Interface1, Interface2, Interface3, Interface4, Interface5, Interface6, Interface7, Interface8, Interface9;

    private string text1, text2, text3, text4, text5, text6, text7, text8, text9;

    private bool changeText, timeToCheck;

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
        if (tryToConnect.tryConnect)
        {
            timeToCheck = true;

            if (changeText)
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
                changeText = false;
            }

            if (timeToCheck)
            {
                StartCoroutine(RFIDDataCheck());
            }
        }

        else
        {
            timeToCheck = false;
            FM1.text = ("No connection to Machine 1.");
            FM2.text = ("No connection to Machine 2.");
            FM3.text = ("No connection to Machine 3.");
            FM4.text = ("No connection to Machine 4.");
            FM5.text = ("No connection to Machine 5.");
            FM6.text = ("No connection to Machine 6.");
            FM7.text = ("No connection to Machine 7.");
            FM8.text = ("No connection to Machine 8.");
            FM9.text = ("No connection to Machine 9.");
            changeText = true;
        }
    }

    IEnumerator RFIDDataCheck()
    {
        timeToCheck = false;

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

        var THREE = Interface3.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (THREE == null)
        {
            FM3.text = ("No reading RFID machine 3");
        }
        else
        {
            text1 = ("The last RFID tag at machine 3 was ") + THREE.ToString();
            FM3.text = text3;
        }

        var FOUR = Interface4.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (FOUR == null)
        {
            FM4.text = ("No reading RFID machine 4");
        }
        else
        {
            text4 = ("The last RFID tag at machine 4 was ") + FOUR.ToString();
            FM4.text = text4;
        }

        var FIVE = Interface5.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (FIVE == null)
        {
            FM5.text = ("No reading RFID machine 5");
        }
        else
        {
            text5 = ("The last RFID tag at machine 5 was ") + FIVE.ToString();
            FM5.text = text5;
        }

        var SIX = Interface6.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (SIX == null)
        {
            FM6.text = ("No reading RFID machine 6");
        }
        else
        {
            text6 = ("The last RFID tag at machine 6 was ") + SIX.ToString();
            FM6.text = text6;
        }

        var SEVEN = Interface7.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (SEVEN == null)
        {
            FM7.text = ("No reading RFID machine 7");
        }
        else
        {
            text7 = ("The last RFID tag at machine 7 was ") + SEVEN.ToString();
            FM7.text = text7;
        }

        var EIGHT = Interface8.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (EIGHT == null)
        {
            FM8.text = ("No reading RFID machine 8");
        }
        else
        {
            text8 = ("The last RFID tag at machine 8 was ") + EIGHT.ToString();
            FM8.text = text8;
        }

        var NINE = Interface9.ReadNodeValue("ns=3;s=\"dbRfidData\".\"ID1\".\"iCarrierID\"");
        if (NINE == null)
        {
            FM9.text = ("No reading RFID machine 9");
        }
        else
        {
            text9 = ("The last RFID tag at machine 9 was ") + NINE.ToString();
            FM9.text = text9;
        }

        yield return new WaitForSeconds(0.5f);

        timeToCheck = true;
    }
}

    

