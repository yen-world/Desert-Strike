using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public GameObject SquadUI;

    public GameObject UnitUI;

    // 스크롤뷰의 위치를 초기화하기 위한 변수
    public RectTransform ScrollContent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SquadUIOpen()
    {
        // 스크롤뷰 위치 초기화
        float x = ScrollContent.anchoredPosition.x;
        ScrollContent.anchoredPosition = new Vector2(x, 0);

        // UI창 활성화
        SquadUI.SetActive(true);
    }

    public void UnitUIOpen()
    {
        UnitUI.SetActive(true);
    }
}
