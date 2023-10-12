using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //각 블록은 자기 자리의 grid를 받아와야함. 
    //또한 블록이 제자리를 찾아 갔을 때, 자기가 올라가있는 그리드를 저장하고 있어야함.
    public GameObject grid;
    public List<GameObject> gridList = new List<GameObject>();

    public bool completeFlag = false;

    private void Update() {
        if(completeFlag){
            this.transform.position = gridList[0].transform.position;
            gridList[0].transform.tag = "OnGrid";
            completeFlag = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Grid"){
            print("Grid");
            gridList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.tag == "Grid"){
            print("exit");
            gridList.Remove(other.gameObject);
        }
    }
}
