using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MinimapMoving : MonoBehaviour
{
    float speed = 3.0f;
    float maxZoom = 36f;
    float minZoom = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            this.transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            this.transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            this.transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            this.transform.position += Vector3.down * Time.deltaTime * speed;
        }
        //카메라의 줌 인 줌 아웃
        if(Input.GetKey(KeyCode.Plus)){
            if(this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize < minZoom){
                this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = minZoom;
            }
            this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize -= 0.1f;
        }
        if(Input.GetKey(KeyCode.Minus)){
            if(this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize > maxZoom){
                this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = maxZoom;
            }
            this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize += 0.1f;
        }
    }
}
