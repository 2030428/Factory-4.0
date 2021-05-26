using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class CurrentOrders: MonoBehaviour
{
    public List<string> CurrentOrderData = new List<string>();      //cretes list

    public CurrentOrderJSON[] currentOrdersObjectArray;             //creates array of current ofrder jsons

    public string listInfo;                                         //creates string

    public Text info;                                               //ref to text object

    public void ReceieveData(string CurrentOrderStringPHPMany)
    {
        string newCurrentOrderStringPHPMany = fixJson(CurrentOrderStringPHPMany);       //new string with fixed json string

        //Debug.Log(newCurrentOrderStringPHPMany);                                      //debug check

        currentOrdersObjectArray = JsonHelper.FromJson<CurrentOrderJSON>(newCurrentOrderStringPHPMany);     //array of fixed json strings

        CurrentOrderData.Clear();                                                       //clears list data
        listInfo = "";                                                                  //empties string

        for (int i = 0; i < currentOrdersObjectArray.Length; i++)                       //for each item in array length
        {
            //Debug.Log("ONo:" + currentOrdersObjectArray[i].ONo + ", Company:" + currentOrdersObjectArray[i].Company + ", Planned Start:" + currentOrdersObjectArray[i].PlannedStart + ", Planned End:" + currentOrdersObjectArray[i].PlannedEnd + ", State:" + currentOrdersObjectArray[i].State);
            //debug check

            CurrentOrderData.Add("Order Number: " + currentOrdersObjectArray[i].ONo + ", Company Name: " + currentOrdersObjectArray[i].Company + ", Planned Start Time: " + currentOrdersObjectArray[i].PlannedStart + ", Planned End Time: " + currentOrdersObjectArray[i].PlannedEnd + ", Build State: " + currentOrdersObjectArray[i].State);
            //adds array values to the list
        }

        foreach(var listMember in CurrentOrderData)                 //for each element of the list
        {
            listInfo += listMember.ToString() + "\n" + "\n";        //add to the string
        }

        info.text = listInfo;                                       //set text value to the string
    }

    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    public void GetRequestPublic()
    {
        StartCoroutine(GetRequest("http://172.21.0.90/SQLData.php?Command=currentOrders"));     //calls coroutine and sets string
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    ReceieveData(webRequest.downloadHandler.text);
                    Debug.LogError("Current Orders Success");

                    break;
            }
        }
    }
}
