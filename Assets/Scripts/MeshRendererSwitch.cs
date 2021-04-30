using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererSwitch : MonoBehaviour
{
    public GameObject Factory;
    private bool meshesOff;
    private int numAtStart, currentNum;

    public void Update()
    {
        if (meshesOff)
        {
            currentNum = Factory.transform.childCount;

            if (numAtStart < currentNum)
            {
                TurnOffMeshes();
            }
        }
    }

    public void TurnOffMeshes()
    {
        meshesOff = true;

        MeshRenderer[] FactoryItems = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in FactoryItems)
            r.enabled = false;
        
        SpriteRenderer[] FactorySprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in FactorySprites)
            s.enabled = false;

        numAtStart = Factory.transform.childCount;
    }

    public void TurnOnMeshes()
    {
        meshesOff = false;

        MeshRenderer[] FactoryItems = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in FactoryItems)
            r.enabled = true;

        SpriteRenderer[] FactorySprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in FactorySprites)
            s.enabled = true;
    }
}
