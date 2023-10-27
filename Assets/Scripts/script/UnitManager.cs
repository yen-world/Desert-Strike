using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Unit unit;
    [SerializeField] float speed = 3.0f;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("DirX",Vector3.right.x);
        animator.SetFloat("DirY",Vector3.right.y);
        animator.SetBool("WalkFlag",true);
        this.transform.position += Vector3.right * Time.deltaTime * speed;
        
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
