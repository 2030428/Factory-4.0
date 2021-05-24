using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class cart : MonoBehaviour
{
    public CurrentOrders currentOrders;

    public List<string> cartData = new List<string>();

    public cartJSON[] cartObjectArray;

    public string listInfo;

    public Text info;

    public void ReceieveData(string cartStringPHPMany)
    {
        string newcartStringPHPMany = fixJson(cartStringPHPMany);

        Debug.Log(newcartStringPHPMany);

        cartObjectArray = JsonHelper.FromJson<cartJSON>(cartStringPHPMany);

        cartData.Clear();
        listInfo = "";

        for (int i = 0; i < cartObjectArray.Length; i++)
        {
            Debug.Log("ONo:" + cartObjectArray[i].ONo + ", Carrier ID:" + cartObjectArray[i].CarrierID);
            cartData.Add("ONo:" + cartObjectArray[i].ONo + ", Carrier ID:" + cartObjectArray[i].CarrierID);
        }

        foreach (var listMember in cartData)
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
        for (int i = 0; i < currentOrders.currentOrdersObjectArray.Length; i++)
        {
            var ONO = currentOrders.currentOrdersObjectArray[i].ONo;

            StartCoroutine(GetRequest(" http://172.21.0.90/SQLDataStudents.php?Command=cart?ONo=" + ONO));
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
}
