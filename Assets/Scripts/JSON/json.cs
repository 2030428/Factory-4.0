using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
public class json : MonoBehaviour
{
    public string OrderStringPHPSingle = "{\"PNo\":\"210\",\"Description\":\"front cover black\",\"Picture\":\"Pictures.png\"}";
    public string OrderStringPHPMany = "{\"PNo\":\"210\",\"Description\":\"front cover black\",\"Picture\":\"Pictures.png\"}";
    // Start is called before the first frame update
    void Start()
    {
        ////string jsonString = "[{ \"playerId\": \"1\", \"playerLoc\": \"Powai\" }, {\"playerId\": \"2\",\"playerLoc\": \"Andheri\"},{\"playerId\": \"3\",\"playerLoc\": \"Churchgate\"}]";
        //string jsonString1 = "{ \"name\": \"marc\", \"lives\": \"1\", \"health\": \"10\" }" ; //, { 'name': 'seb', 'lives': '1','health': '10'};";


        //string jsonString2 = "{\"playerId\":\"8484239823\",\"playerLoc\":\"Powai\",\"playerNick\":\"Random Nick\"}";
        //Player player = JsonUtility.FromJson<Player>(jsonString2);
        //Debug.Log(player.playerLoc);


        //string jsonString3 = "{\r\n    \"Items\": [\r\n        {\r\n            \"playerId\": \"8484239823\",\r\n            \"playerLoc\": \"Powai\",\r\n            \"playerNick\": \"Random Nick\"\r\n        },\r\n        {\r\n            \"playerId\": \"512343283\",\r\n            \"playerLoc\": \"User2\",\r\n            \"playerNick\": \"Rand Nick 2\"\r\n        }\r\n    ]\r\n}";

        //Player[] playerArray = JsonHelper.FromJson<Player>(jsonString3);
        //Debug.Log(playerArray[0].playerLoc);
        //Debug.Log(playerArray[1].playerLoc);

        
        OrderOptionJson orderOptionObject = JsonUtility.FromJson<OrderOptionJson>(OrderStringPHPSingle);
        Debug.Log("PNo:" + orderOptionObject.PNo + ", Description:" + orderOptionObject.Description);

        string severCodeFixOrderStringPHPMany = fixJson(OrderStringPHPMany);
        OrderOptionJson[] orderOptionObjectArray = JsonHelper.FromJson<OrderOptionJson>(severCodeFixOrderStringPHPMany);
        Debug.Log("PNo:" + orderOptionObjectArray[0].PNo + ", Description:" + orderOptionObjectArray[0].Description);
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
