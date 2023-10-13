using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class UnitListScript : MonoBehaviour
{
    [SerializeField] Slider unitTimer;
    [SerializeField] bool myCoroutineRunning;
    public GameObject parentObj; //puzzle Group
    public List<GameObject> gridGroup;
    [SerializeField] GameObject UnitSpawnPotal;
    [SerializeField] GameObject unitPrefab;
    GameManager theGM;
    Unit unit;

    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UnitTimer());
        theGM = FindObjectOfType<GameManager>();
        gridGroup = parentObj.GetComponent<PuzzleGroupScript>().gridGroup;
        UnitSpawnPotal = GameObject.Find("UnitSpawnPotal");
        //theGM에서 unitprefabs에 있는 요소 중, unitCode가 같은 프리팹 가져오기
        unitPrefab = theGM.unitPrefabs
        .Find(x => x.name == parentObj.GetComponent<PuzzleGroupScript>().unit_Code.ToString());
        unit = unitPrefab.GetComponent<UnitManager>().unit;
        unitTimer.maxValue = unit.unit_ListTime;
        unitTimer.value = unitTimer.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(!myCoroutineRunning){
            for(int i = 0; i < gridGroup.Count; i++) {
                gridGroup[i].gameObject.tag = "Grid";   
            }
            Destroy(parentObj);
            Destroy(this.gameObject);
        }
        time += Time.deltaTime;
        if(time > unit.unit_SpawnTime){
            Instantiate(unitPrefab, UnitSpawnPotal.transform.position, Quaternion.identity,UnitSpawnPotal.transform);
            time = 0f;
        }
        
    }

    IEnumerator UnitTimer(){
        myCoroutineRunning = true;
        for(float i = unitTimer.value;i > 0;i = i - 0.01f){
            unitTimer.value = i;
            
            yield return new WaitForSeconds(0.1f);
        }
        myCoroutineRunning = false;
    }
}
