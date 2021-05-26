using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSwitcher : MonoBehaviour
{
    public BuildOptionsButton buildOptions;

    public ShowOrderBar showOrderBar;
    
    public MeshRendererSwitch MeshSwitch;           //ref to meshrendswitch script

    public GameObject switchToAR, switchTo3D, ARCam, ThreeDCam, areaTargets;     //refs to game objects

    // Start is called before the first frame update
    void Start()
    {
        ARMode();                                   //calls this function at start
    }

    public void ARMode()
    {
        ThreeDCam.SetActive(false);                 //sets GO inactive
        ARCam.SetActive(true);                      //sets GO active
        switchToAR.SetActive(false);                //sets GO inactive
        switchTo3D.SetActive(true);                 //sets GO ctive
        areaTargets.SetActive(true);                // ""
        MeshSwitch.TurnOffMeshes();                 //calls function from refernced script
        showOrderBar.HideBars();                    // ""
        buildOptions.HideBar();                     // ""
    }

    public void ThreeDMode()                        //same as above function but opposite
    {
        ARCam.SetActive(false);
        ThreeDCam.SetActive(true);
        switchToAR.SetActive(true);
        switchTo3D.SetActive(false);
        areaTargets.SetActive(false);
        MeshSwitch.TurnOnMeshes();
        showOrderBar.HideBars();                    
        buildOptions.HideBar();                    
    }
}
