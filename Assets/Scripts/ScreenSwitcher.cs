using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSwitcher : MonoBehaviour
{
    public MeshRendererSwitch MeshSwitch;

    public GameObject switchToAR, switchTo3D, ARCanvasDisplay, ARCam, ThreeDCam;

    // Start is called before the first frame update
    void Start()
    {
        ARMode();
    }

    public void ARMode()
    {
        ThreeDCam.SetActive(false);
        ARCam.SetActive(true);
        switchToAR.SetActive(false);
        switchTo3D.SetActive(true);
        ARCanvasDisplay.SetActive(true);
        MeshSwitch.TurnOffMeshes();
    }

    public void ThreeDMode()
    {
        ARCam.SetActive(false);
        ThreeDCam.SetActive(true);
        switchToAR.SetActive(true);
        switchTo3D.SetActive(false);
        ARCanvasDisplay.SetActive(false);
        MeshSwitch.TurnOnMeshes();
    }
}
