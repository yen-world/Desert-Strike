using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleScript : MonoBehaviour ,IDragHandler, IEndDragHandler, IBeginDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData){
        print("Drag");
    }

    public void OnDrag(PointerEventData eventData1){
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0f);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(objectPos.x, objectPos.y, 0f);
    }

    public void OnEndDrag(PointerEventData eventData2){

    }
}
