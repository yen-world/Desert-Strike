using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class PuzzleGroupScript : MonoBehaviour, IDragHandler,IBeginDragHandler, IEndDragHandler
{
    //퍼즐 그룹의 이름 뒤에 오는 숫자는 블록의 갯수이다.
    //퍼즐 그룹은 그리드를 가져온다.
    //가져온 그리드를 조회해야한다. 즉 그리드에 번호가 있으면 편할듯하다...

    public int unit_Code;

    public List<GameObject> gridGroup = new List<GameObject>();
    public List<Block> blocks = new List<Block>();

    [SerializeField] GameObject thisParent; //PuzzleSpawnPos
    [SerializeField] GameObject blocksObj;
    [SerializeField] GameObject blockInfoImg;

    [SerializeField] GameObject unitListPrefab;
    [SerializeField] GameObject unitListParent;
 
    [SerializeField] int blockShapeCode;
    [SerializeField] bool completeFlag = false;
    GameManager theGM;

    [Header("PuzzleImg")]
    [SerializeField] Image blockShapeImg;

    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        blockShapeCode = UnityEngine.Random.Range(0,theGM.shapeList.Count);
        thisParent = this.transform.parent.gameObject;
        blocksObj = Instantiate(theGM.SetShape(blockShapeCode),this.transform.position, Quaternion.identity,
        this.transform);
        for(int i = 0; i < blocksObj.transform.childCount; i++) {
            blocks.Add(blocksObj.transform.GetChild(i).GetComponent<Block>());
        }
        blocksObj.SetActive(false);
        unitListParent = GameObject.Find("UnitListGroup");
        unit_Code = UnityEngine.Random.Range(1001,1008);
        blockShapeImg.sprite = theGM.blockImg.Find(x => x.name == "B300" + (blockShapeCode+1).ToString());
       
    }
    private void Update()
    {
        if(Input.GetMouseButton(0)){
            print(Input.mousePosition + " " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    public void OnBeginDrag(PointerEventData eventData){
        //블록 모양으로 변환
        //일단 잘못 놨을수도 있으니 블록 그리드를 모두 지워야함.
        blocksObj.SetActive(true);
        blockInfoImg.SetActive(false);
        gridGroup.Clear();
    }
    public void OnDrag(PointerEventData eventData1){
        if(!completeFlag){
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0f);
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3(objectPos.x, objectPos.y, 0f);
        }
    }
    public void OnEndDrag(PointerEventData eventData2){
        try{
            //그리드 정보 여기로 불러와야됨.

            for(int i = 0; i < blocks.Count; i++) {
                gridGroup.Add(blocks[i].gridList[0]);
            }
            if(gridGroup.Count == blocks.Count){ //수가 같으면 정확한 위치에 놓여있는거임.
                for(int i = 0; i < blocks.Count; i++) {
                    blocks[i].completeFlag = true;
                }
                completeFlag = true;
                //유닛 리스트에 추가하는 함수 
                var unitlist = Instantiate(unitListPrefab, unitListParent.transform.position, 
                Quaternion.identity, unitListParent.transform);
                unitlist.GetComponent<UnitListScript>().parentObj = this.gameObject;
                thisParent.GetComponent<SpawnerScript>().spawnTimerFlag = true;

                //유닛 리스트에 추가된 프리팹의 유닛 설정 (이건 게임메니저에서 불러오는게 나을듯...)
            }
        }catch(ArgumentOutOfRangeException){//블록이 현재 제자리에 없는경우임. 이럴땐 스폰 위치로 다시 이동시켜야함.
            
            this.transform.position = thisParent.transform.position;
            blocksObj.SetActive(false);
            blockInfoImg.SetActive(true);
        }
        
        
    }
}
