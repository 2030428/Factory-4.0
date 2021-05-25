using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class tblStepMostRecent: MonoBehaviour
{
    public CurrentOrders currentOrders;

    public List<string> tblStepData = new List<string>();

    public string listInfo;

    public Text info;

    public tblStepJSON[] tblStepObjectArray;

    public void ReceieveData(string tblStepStringPHPMany)
    {
        string newtblStepStringPHPMany = fixJson(tblStepStringPHPMany);

        Debug.Log(newtblStepStringPHPMany);

        tblStepObjectArray = JsonHelper.FromJson<tblStepJSON>(newtblStepStringPHPMany);

        tblStepData.Clear();
        listInfo = "";

        for (int i = 0; i < tblStepObjectArray.Length; i++)
        {
            Debug.Log("Order Number: " + tblStepObjectArray[i].ONo + ", is at Resource: " + tblStepObjectArray[i].ResourceID + ", and Step Number: " + tblStepObjectArray[i].StepNo + "." + "The next Step Number is: " + tblStepObjectArray[i].NextStepNo + ", Planned Start Time:" + tblStepObjectArray[i].PlannedStart + ", Planned End Time:" + tblStepObjectArray[i].PlannedEnd + ", Description:" + tblStepObjectArray[i].Description);

            info.text = ("Order Number: " + tblStepObjectArray[i].ONo + ", is at Resource: " + tblStepObjectArray[i].ResourceID + ", and Step Number: " + tblStepObjectArray[i].StepNo + "." + "The next Step Number is: " + tblStepObjectArray[i].NextStepNo + ", Planned Start Time:" + tblStepObjectArray[i].PlannedStart + ", Planned End Time:" + tblStepObjectArray[i].PlannedEnd + ", Description:" + tblStepObjectArray[i].Description);
        }

    }

    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    public void GetRequestPublic()
    {
        //for (int i = 0; i < currentOrders.currentOrdersObjectArray.Length; i++)
        //{
        //    var ONO = currentOrders.currentOrdersObjectArray[i].ONo;

            StartCoroutine(GetRequest("http://172.21.0.90/SQLDataStudents.php?Command=tblStep")) ; //" + ONO));
        //}

        ////StartCoroutine(GetRequest(" http://172.21.0.90/SQLDataStudents.php?Command=tblStep?ONo=2579 "));

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
                    Debug.LogError("Finished Orders Success");

                    break;
            }
        }
    }
}
