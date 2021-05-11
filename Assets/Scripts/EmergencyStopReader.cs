using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game4automation;
using UnityEngine.UI;

public class EmergencyStopReader : MonoBehaviour
{
    public OPCUA_Interface Interface1, Interface2, Interface3, Interface4, Interface5, Interface6, Interface7, Interface8, Interface9;

    public GameObject overlayGood, overlayEmergency, idle1, good1, emergency1, idle2, good2, emergency2, idle3, good3, emergency3, idle4, good4, emergency4, idle5, good5, emergency5, idle6, good6, emergency6, idle7, good7, emergency7, idle8, good8, emergency8, idle9, good9, emergency9;

    public Text info; 

    private string active, inactive;

    public bool checkEmgStop;

    // Start is called before the first frame update
    void Start()
    {
        active = "False";
        inactive = "True";
        checkEmgStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkEmgStop)
        {
            StartCoroutine(EmgStopCheck());
        }
    }

    IEnumerator EmgStopCheck()
    {
        checkEmgStop = false;

        yield return new WaitForSeconds(0.05f);
        var EMG1 = Interface1.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG1 == null)
        {
            idle1.SetActive(true);
            emergency1.SetActive(false);
            good1.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }
        if (EMG1 != null && EMG1.ToString() == active)
        {
            emergency1.SetActive(true);
            idle1.SetActive(false);
            good1.SetActive(false);
            overlayGood.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 1!";
        }
        if (EMG1 != null && EMG1.ToString() == inactive)
        {
            good1.SetActive(true);
            idle1.SetActive(false);
            emergency1.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";

        }

        yield return new WaitForSeconds(0.05f);
        var EMG2 = Interface2.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG2 == null)
        {
            idle2.SetActive(true);
            emergency2.SetActive(false);
            good2.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";

        }
        if (EMG2 != null && EMG2.ToString() == active)
        {
            emergency2.SetActive(true);
            idle2.SetActive(false);
            good2.SetActive(false);
            overlayGood.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 2!";
        }
        if (EMG2 != null && EMG2.ToString() == inactive)
        {
            good2.SetActive(true);
            idle2.SetActive(false);
            emergency2.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";

        }

        yield return new WaitForSeconds(0.05f);
        var EMG3 = Interface3.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG3 == null)
        {
            idle3.SetActive(true);
            emergency3.SetActive(false);
            good3.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";

        }
        if (EMG3 != null && EMG3.ToString() == active)
        {
            emergency3.SetActive(true);
            idle3.SetActive(false);
            good3.SetActive(false);
            overlayGood.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 3!";
        }
        if (EMG3 != null && EMG3.ToString() == inactive)
        {
            good3.SetActive(true);
            idle3.SetActive(false);
            emergency3.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";

        }

        yield return new WaitForSeconds(0.05f);
        var EMG4 = Interface4.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG4 == null)
        {
            idle4.SetActive(true);
            emergency4.SetActive(false);
            good4.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";

        }
        if (EMG4 != null && EMG4.ToString() == active)
        {
            emergency4.SetActive(true);
            idle4.SetActive(false);
            good4.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 4!";
        }
        if (EMG4 != null && EMG4.ToString() == inactive)
        {
            good4.SetActive(true);
            idle4.SetActive(false);
            emergency4.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";

        }

        yield return new WaitForSeconds(0.05f);
        var EMG5 = Interface5.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG5 == null)
        {
            idle5.SetActive(true);
            emergency5.SetActive(false);
            good5.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }
        if (EMG5 != null && EMG5.ToString() == active)
        {
            emergency5.SetActive(true);
            idle5.SetActive(false);
            good5.SetActive(false);
            good4.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 5!";
        }
        if (EMG5 != null && EMG5.ToString() == inactive)
        {
            good5.SetActive(true);
            idle5.SetActive(false);
            emergency5.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }

        yield return new WaitForSeconds(0.05f);
        var EMG6 = Interface6.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG6 == null)
        {
            idle6.SetActive(true);
            emergency6.SetActive(false);
            good6.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }
        if (EMG6 != null && EMG6.ToString() == active)
        {
            emergency6.SetActive(true);
            idle6.SetActive(false);
            good6.SetActive(false);
            good4.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 6!";
        }
        if (EMG6 != null && EMG6.ToString() == inactive)
        {
            good6.SetActive(true);
            idle6.SetActive(false);
            emergency6.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }

        yield return new WaitForSeconds(0.05f);
        var EMG7 = Interface7.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG7 == null)
        {
            idle7.SetActive(true);
            emergency7.SetActive(false);
            good7.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }
        if (EMG7 != null && EMG7.ToString() == active)
        {
            emergency7.SetActive(true);
            idle7.SetActive(false);
            good7.SetActive(false);
            good4.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 7!";
        }
        if (EMG7 != null && EMG7.ToString() == inactive)
        {
            good7.SetActive(true);
            idle7.SetActive(false);
            emergency7.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }

        yield return new WaitForSeconds(0.05f);
        var EMG8 = Interface8.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG8 == null)
        {
            idle8.SetActive(true);
            emergency8.SetActive(false);
            good8.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }
        if (EMG8 != null && EMG4.ToString() == active)
        {
            emergency8.SetActive(true);
            idle4.SetActive(false);
            good8.SetActive(false);
            good4.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 8!";
        }
        if (EMG8 != null && EMG8.ToString() == inactive)
        {
            good8.SetActive(true);
            idle8.SetActive(false);
            emergency8.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }

        yield return new WaitForSeconds(0.05f);
        var EMG9 = Interface9.ReadNodeValue("ns=3;s=\"dbOpPanel\".\"OpPanelBtn\".\"xEmStop\"");
        if (EMG9 == null)
        {
            idle9.SetActive(true);
            emergency9.SetActive(false);
            good9.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }
        if (EMG9 != null && EMG9.ToString() == active)
        {
            emergency9.SetActive(true);
            idle9.SetActive(false);
            good9.SetActive(false);
            good4.SetActive(false);
            overlayEmergency.SetActive(true);
            info.text = "Check emergency on Machine 9!";
        }
        if (EMG9 != null && EMG9.ToString() == inactive)
        {
            good9.SetActive(true);
            idle9.SetActive(false);
            emergency9.SetActive(false);
            overlayGood.SetActive(true);
            overlayEmergency.SetActive(false);
            info.text = "No emergency";
        }

        yield return new WaitForSeconds(0.5f);

        checkEmgStop = true;
    }
}
