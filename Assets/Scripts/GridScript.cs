using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridScript : MonoBehaviour
{
    Image col;
    private void Start() {
        col = this.transform.GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        col.color = new Color(col.color.r, col.color.g, col.color.b, 1f);
        print("change");
    }

    private void OnTriggerExit2D(Collider2D other) {
        col.color = new Color(col.color.r, col.color.g, col.color.b, 0.5f);
        print("recovery");
    }

}
