using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour
{
    [SerializeField]
    private GameObject manualImg;
    public void OnClick()
    {
        manualImg.SetActive(true);   
    }

    public void OnExit()
    {
        manualImg.SetActive(false);
    }
}
