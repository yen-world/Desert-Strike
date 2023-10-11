using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitListScript : MonoBehaviour
{
    [SerializeField] Slider unitTimer;
    [SerializeField] bool myCoroutineRunning;
    public GameObject parentObj;

    GameManager theGM;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UnitTimer());
        theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!myCoroutineRunning){
            Destroy(parentObj);
            Destroy(this.gameObject);
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