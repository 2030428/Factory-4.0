using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererSwitch : MonoBehaviour
{
    public GameObject Factory;                          //ref to game object
    private bool meshesOff;                             //creates bool
    private int numAtStart, currentNum;                 //creates ints

    public void Update()
    {
        if (meshesOff)                                  //if true....
        {
            currentNum = Factory.transform.childCount;  //sets int value to number of children of GO

            if (numAtStart < currentNum)                //if this int is less than the other...
            {
                TurnOffMeshes();                        //call this function
            }
        }
    }

    public void TurnOffMeshes()
    {
        meshesOff = true;                               //sets bool

        MeshRenderer[] FactoryItems = GetComponentsInChildren<MeshRenderer>();          //creats array of factory item children
        foreach (MeshRenderer r in FactoryItems)                                        //for each mesh renderer in that array...
            r.enabled = false;                                                          //disable
        
        SpriteRenderer[] FactorySprites = GetComponentsInChildren<SpriteRenderer>();    //same as above but for any sprites
        foreach (SpriteRenderer s in FactorySprites)
            s.enabled = false;

        numAtStart = Factory.transform.childCount;      //sets int value
    }

    public void TurnOnMeshes()                          //same as above function but opposite
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
