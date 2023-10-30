using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class UnitListScript : MonoBehaviour
{
    public Slider unitTimer;
    [SerializeField] bool listFlag = true;//리스트가 현재 생성되어 있는지 검사하는 flag
    public GameObject parentObj; //puzzle Group
    public List<GameObject> gridGroup;
    [SerializeField] GameObject UnitSpawnPotal;
    [SerializeField] GameObject unitPrefab;
    GameManager theGM;
    public Unit unit;

    float time = 0f;
    float listTime;
    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();
        gridGroup = parentObj.GetComponent<PuzzleGroupScript>().gridGroup;
        UnitSpawnPotal = GameObject.Find("UnitSpawnPotal");
        //theGM에서 unitprefabs에 있는 요소 중, unitCode가 같은 프리팹 가져오기
        unitPrefab = theGM.unitPrefabs
        .Find(x => x.name == parentObj.GetComponent<PuzzleGroupScript>().unit_Code.ToString());
        unit = unitPrefab.GetComponent<UnitManager>().unit;
        unitTimer.maxValue = unit.unit_ListTime;
        listTime = unit.unit_ListTime;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        listTime -= Time.deltaTime;
        unitTimer.value = listTime;
        if(time > unit.unit_SpawnTime){
            //타이머에 따라 유닛 생성
            Instantiate(unitPrefab, UnitSpawnPotal.transform.position, Quaternion.identity,UnitSpawnPotal.transform);
            time = 0f;
        }

        if(listTime < 0){
            for(int i = 0; i < gridGroup.Count; i++) {
                gridGroup[i].gameObject.tag = "Grid";   
            }
            Destroy(parentObj);
            Destroy(this.gameObject);
        }
    }
}
