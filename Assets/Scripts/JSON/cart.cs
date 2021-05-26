using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class cart : MonoBehaviour
{
    public List<string> cartData = new List<string>();              //creates list

    public string listInfo;                                         //creates string

    public Text info;                                               //ref to text object

    public cartJSON[] cartArray;                                    //array of cart jsons

    public void ReceieveData(string cartStringPHPMany)
    {
        string newcartStringPHPMany = fixJson(cartStringPHPMany);           //new string with fixed json string

        //Debug.Log(newcartStringPHPMany);                                  //debug check

        cartArray = JsonHelper.FromJson<cartJSON>(newcartStringPHPMany);    //array of fixed jsons strings

        cartData.Clear();                                                   //clears list data
        listInfo = "";                                                      //empties string

        for (int i = 0; i < cartArray.Length; i++)                          //for eachcartarray in length
        {
            //Debug.Log("Order Number: " + cartArray[i].ONo + ", is on Cart Number: " + cartArray[i].CarrierID);        //debug check

            cartData.Add("Order Number: " + cartArray[i].ONo + ", is on Cart Number: " + cartArray[i].CarrierID);       //adds each array value to the list
        }

        foreach (var listMember in cartData)                                //for each element of the list
        {
            listInfo += listMember.ToString() + "\n" + "\n";                //add it to string
        }

        info.text = listInfo;                                               //set text value to string
    }

    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    public void GetRequestPublic()
    {
        StartCoroutine(GetRequest("http://172.21.0.90/SQLData.php?Command=cart"));      //calls coroutine and sets string
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

