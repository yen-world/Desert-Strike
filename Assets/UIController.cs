using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject content;
    public RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = content.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (content.transform.childCount >= 15)
        {
            SetHeight();
        }
    }


    public void SetHeight()
    {
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 1800 + Mathf.CeilToInt((content.transform.childCount - 15) / 3f) * 340);
    }
}
