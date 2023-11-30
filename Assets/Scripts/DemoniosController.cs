using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoniosController : MonoBehaviour
{
    private Animator anim;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
