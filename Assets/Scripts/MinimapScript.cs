using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{   
    public LayerMask onUIlayer, notUIlayer;
    [SerializeField] bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMinimapBtnClick(){
        if(flag){
            Camera.main.cullingMask = notUIlayer;
            flag = !flag;
        }
        else{
            Camera.main.cullingMask = onUIlayer;
            flag = !flag;
        }
    }
}
