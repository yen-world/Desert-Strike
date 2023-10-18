using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonScript : MonoBehaviour
{
    [Header("UI")]
    // [SerializeField] GameObject uiCam;
    // [SerializeField] GameObject minimapCam;
    [SerializeField] GameObject mainUI;
    public void OnMinimapBtnClick(){
        bool flag = mainUI.GetComponent<Animator>().GetBool("ChangeMode");
        mainUI.GetComponent<Animator>().SetBool("ChangeMode",!flag);
        // uiCam.SetActive(!flag);
        // minimapCam.SetActive(flag);
    }
}
