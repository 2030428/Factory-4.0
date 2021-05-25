using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class tblOrderPos: MonoBehaviour
{
    public CurrentOrders currentOrders;

    public List<string> tblOrderPosData = new List<string>();

    public string listInfo;

    public Text info;

    public tblOrderPosJSON[] tblOrderPosObjectArray;

    public void ReceieveData(string tblOrderPosStringPHPMany)
    {
        string newtblOrderPosStringPHPMany = fixJson(tblOrderPosStringPHPMany);

        Debug.Log(newtblOrderPosStringPHPMany);

        tblOrderPosObjectArray = JsonHelper.FromJson<tblOrderPosJSON>(newtblOrderPosStringPHPMany);

        tblOrderPosData.Clear();
        listInfo = "";

        for (int i = 0; i < tblOrderPosObjectArray.Length; i++)
        {
            Debug.Log("ONo:" + tblOrderPosObjectArray[i].ONo + ", Step No:" + tblOrderPosObjectArray[i].StepNo ) ;

            tblOrderPosData.Add("Order Number: " + tblOrderPosObjectArray[i].ONo + ", is at Step Number: " + tblOrderPosObjectArray[i].StepNo);
        }

        foreach (var listMember in tblOrderPosData)
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
        //for (int i = 0; i < currentOrders.currentOrdersObjectArray.Length; i++)
        //{
        //    var ONO = currentOrders.currentOrdersObjectArray[i].ONo;

            StartCoroutine(GetRequest("http://172.21.0.90/SQLDataStudents.php?Command=tblOrderPos")) ; //" + ONO));
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
