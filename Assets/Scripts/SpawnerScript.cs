using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] Slider timeSlider;
    [SerializeField] Text timeText;
    [SerializeField] GameObject puzzlePrefab;

    // Update is called once per frame
    void Update()
    {
        if(this.transform.childCount > 1){
            timeSlider.gameObject.SetActive(false);
        }
        else{
            timeSlider.gameObject.SetActive(true);
            // StartCoroutine(TimeCoroutine());
            timeSlider.value -= 0.001f;
            timeText.text = timeSlider.value.ToString("F1");
            if(timeSlider.value == 0){
                //퍼즐 생성부 추후에 여러 값들을 여기서 초기화 해야될듯..?
                Instantiate(puzzlePrefab, this.transform.position, Quaternion.identity, this.transform);
                timeSlider.gameObject.SetActive(false);
                timeSlider.value = 3f;
            }
        }
    }

    // IEnumerator TimeCoroutine(){
        
    //     yield return new WaitForSeconds(0.1f);
    // }
}

