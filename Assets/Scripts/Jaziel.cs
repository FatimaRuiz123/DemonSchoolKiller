using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaziel : MonoBehaviour
{
    Animator animator;
    float verInput;
    private float speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verInput= Input.GetAxis("Vertical");

        if (verInput==0){
            animator.SetInteger("Estado",0);
        }else if (verInput>0){
            transform.Translate(Vector3.forward * Time.deltaTime * verInput * 10);
            animator.SetInteger("Estado",1); 
        }
    }
}
