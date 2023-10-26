using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonScript : MonoBehaviour
{
    [Header("OnMinimapClick Obj")]
    public GameObject mainVirCam;
    public GameObject gameVirCam;
    public GameObject UIObj;
    public void OnMinimapClick(){
        mainVirCam.SetActive(!mainVirCam.activeSelf);
        gameVirCam.SetActive(!gameVirCam.activeSelf);
        UIObj.GetComponent<Animator>().SetBool("UIChangeTrigger",
        !UIObj.GetComponent<Animator>().GetBool("UIChangeTrigger"));
    }
}
