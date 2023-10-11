using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle : MonoBehaviour,IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] Unit unit;

    [SerializeField] GameObject parentSpawner;
    [SerializeField] GameObject unitTimer;

    public List<GameObject> gridList = new List<GameObject>();

    [SerializeField] bool completeFlag = false; //블록이 그리드위에 올라갔다면 true 아니면 false

    GameManager theGM;

    [SerializeField] GameObject onGameObj; //다른 블록 위에 있는지 검사


    private void Start()
    {
        parentSpawner = transform.parent.gameObject;
        theGM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(completeFlag){

        }
    }


    public void OnBeginDrag(PointerEventData eventData){
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(100f,100f);
        onGameObj = null;
    }

    public void OnDrag(PointerEventData eventData){
        if(!completeFlag){
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0f);
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3(objectPos.x, objectPos.y, 0f);
        } 
    }
    public void OnEndDrag(PointerEventData eventData){
        if(gridList.Count > 0){ //한가지 경우와 두가지 이상일 경우는 같은 연산을 해야되기때문에 합쳤음.
            if(onGameObj != null){
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(160f,160f);
                transform.position = parentSpawner.transform.position;
            }
            else{
                Vector3 nextPos = gridList[0].transform.position;
                for(int i = 0; i < gridList.Count; i++) {
                    if(Vector3.Distance(transform.position, nextPos) > Vector3.Distance(transform.position, gridList[i].transform.position)){
                        nextPos = gridList[i].transform.position;
                    }
                }
                transform.position = nextPos; //가장 가까운 그리드로 위치 이동
                gridList[0].gameObject.tag = "OnGrid";
                parentSpawner = null;
                //unitList에 생성
                var unittimer = Instantiate(unitTimer,theGM.UnitListGroup.transform.position,Quaternion.identity,theGM.UnitListGroup.transform);
                //unittimer 객체는 현재 퍼즐 객체와 같이 삭제되어야 하니 parentObj를 현재 객체로 설정
                unittimer.GetComponent<UnitListScript>().parentObj = this.gameObject;
                completeFlag = true;
                this.gameObject.transform.parent = theGM.puzzlePlacementGroup.transform;
            }
            
        }
        else{
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(160f,160f);
            transform.position = parentSpawner.transform.position;
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
