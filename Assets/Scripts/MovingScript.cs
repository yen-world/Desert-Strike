using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            this.transform.position += Vector3.left * 0.3f *Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            this.transform.position += Vector3.right * 0.3f *Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            this.transform.position += Vector3.up * 0.3f *Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            this.transform.position += Vector3.down * 0.3f *Time.deltaTime;
        }
    }
}
