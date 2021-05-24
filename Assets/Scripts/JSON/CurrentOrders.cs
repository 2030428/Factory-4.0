using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class CurrentOrders: MonoBehaviour
{
    public List<string> CurrentOrderData = new List<string>();

    public CurrentOrderJSON[] currentOrdersObjectArray;

    public string listInfo;

    public Text info;

    public void ReceieveData(string CurrentOrderStringPHPMany)
    {
        string newCurrentOrderStringPHPMany = fixJson(CurrentOrderStringPHPMany);

        Debug.Log(newCurrentOrderStringPHPMany);

        currentOrdersObjectArray = JsonHelper.FromJson<CurrentOrderJSON>(newCurrentOrderStringPHPMany);

        CurrentOrderData.Clear();
        listInfo = "";

        for (int i = 0; i < currentOrdersObjectArray.Length; i++)
        {
            Debug.Log("ONo:" + currentOrdersObjectArray[i].ONo + ", Company:" + currentOrdersObjectArray[i].Company + ", Planned Start:" + currentOrdersObjectArray[i].PlannedStart + ", Planned End:" + currentOrdersObjectArray[i].PlannedEnd + ", State:" + currentOrdersObjectArray[i].State);

            CurrentOrderData.Add("ONo:" + currentOrdersObjectArray[i].ONo + ", Company:" + currentOrdersObjectArray[i].Company + ", Planned Start:" + currentOrdersObjectArray[i].PlannedStart + ", Planned End:" + currentOrdersObjectArray[i].PlannedEnd + ", State:" + currentOrdersObjectArray[i].State);
        }

        foreach(var listMember in CurrentOrderData)
        {
            listInfo += listMember.ToString() + "\n" + "\n"; 
        }

        info.text = listInfo;
    }

    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    public void GetRequestPublic()
    {
        StartCoroutine(GetRequest("http://172.21.0.90/SQLData.php?Command=currentOrders"));
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
