using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* 데이터 조회 명령어
    using Select.Linq;
    (from value in 리스트 select value).함수(Max, Average 등)(item => item.조회할 변수)
*/

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject puzzlePlacementGroup;
    public GameObject UnitListGroup;

    [Header("Lists")]
    public List<GameObject> shapeList = new List<GameObject>();

    public List<GameObject> unitPrefabs = new List<GameObject>();

    public List<Sprite> blockImg = new List<Sprite>();

    public GameObject SetShape(int _code){
        
        return shapeList[_code];
    }
    private void Start() {
        for(int i = 0; i < unitPrefabs.Count; i++) {
            print(unitPrefabs[i].name);
        }
    }
}
