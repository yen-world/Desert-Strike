using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.cullingMask = layer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
