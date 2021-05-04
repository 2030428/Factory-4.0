using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    public GameObject item;

    public void ShowItem()
    {
        item.SetActive(true);
    }

    public void HideItem()
    {
        item.SetActive(false);
    }
}
