using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject puzzlePlacementGroup;
    public GameObject UnitListGroup;

    public List<GameObject> shapeList = new List<GameObject>();

    public GameObject SetShape(int _code){
        
        return shapeList[_code];
    }
}
