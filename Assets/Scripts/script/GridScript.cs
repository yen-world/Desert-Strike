using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GridScript : MonoBehaviour
{
    Image col;
    public int gridNum;
    private void Start() {
        col = this.transform.GetComponent<Image>();
        try{
            if(this.name[8] == ')'){ // 한자리 수일경우  
                gridNum = int.Parse(this.name[7].ToString());
            }
            else{//두자리 수일경우
                gridNum = (int.Parse(this.name[7].ToString()) * 10) + int.Parse(this.name[8].ToString());
            }
        }
        catch(IndexOutOfRangeException){
           gridNum = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // col.color = new Color(col.color.r, col.color.g, col.color.b, 1f);
        print("change");
    }

    private void OnTriggerExit2D(Collider2D other) {
        // col.color = new Color(col.color.r, col.color.g, col.color.b, 0.5f);
        print("recovery");
        // if(other.tag == "Puzzle"){
        //     this.tag = "Grid";
        // }
    }

}
