using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonScript : MonoBehaviour
{
    [Header("OnMinimapClick Obj")]
    public GameObject mainVirCam;
    public GameObject gameVirCam;
    public GameObject MainUIObj;
    public GameObject GameUIObj;
    public void OnMinimapClick(){
        mainVirCam.SetActive(!mainVirCam.activeSelf);
        gameVirCam.SetActive(!gameVirCam.activeSelf);
        MainUIObj.GetComponent<Animator>().SetBool("UIChangeTrigger",
        !MainUIObj.GetComponent<Animator>().GetBool("UIChangeTrigger"));

        GameUIObj.GetComponent<Animator>().SetBool("UIChangeTrigger",
        !GameUIObj.GetComponent<Animator>().GetBool("UIChangeTrigger"));
    }
}
