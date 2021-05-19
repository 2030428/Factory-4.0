using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class OrderOptions: MonoBehaviour
{ 

    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetRequest("http://172.21.0.90/SQLData.php?Command=currentOrders"));

        //// A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    public void ReceieveData(string OrderStringPHPMany)
    {

        //OrderOptionJson orderOptionObject = JsonUtility.FromJson<OrderOptionJson>(OrderStringPHPSingle);
        //Debug.Log("PNo:" + orderOptionObject.PNo + ", Description:" + orderOptionObject.Description);

        string newOrderStringPHPMany = fixJson(OrderStringPHPMany);

        Debug.Log(newOrderStringPHPMany);

        OrderOptionJson[] orderOptionObjectArray = JsonHelper.FromJson<OrderOptionJson>(newOrderStringPHPMany);
        //Debug.Log("PNo:" + orderOptionObjectArray[0].PNo + ", Description:" + orderOptionObjectArray[0].Description);



        for (int i = 0; i < orderOptionObjectArray.Length; i++)
        {
            Debug.Log("PNo:" + orderOptionObjectArray[i].PNo + ", Description:" + orderOptionObjectArray[i].Description);
        }
    }

    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    public void GetRequestPublic()
    {
        StartCoroutine(GetRequest("http://172.21.0.90/SQLData.php?Command=ordersOptions"));
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
                    Debug.LogError("Order Options Success");

                    break;
            }
        }
    }
}
