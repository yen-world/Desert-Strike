using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleController : MonoBehaviour
{
    Image ToggleImage;
    Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        ToggleImage = gameObject.GetComponent<Image>();
        toggle = gameObject.GetComponent<Toggle>();
        if (toggle.isOn)
        {
            ToggleImage.color = new Color32(130, 130, 130, 255);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void isOn()
    {
        ToggleImage.color = new Color32(130, 130, 130, 255);
    }

    public void isOff()
    {
        ToggleImage.color = new Color32(197, 197, 197, 255);

    }
}
