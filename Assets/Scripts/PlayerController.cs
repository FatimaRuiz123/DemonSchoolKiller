using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool conArma;
    public float velocidadMovimiento = 30.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;

    public bool estoyAtacando;
    public bool avanzaSolo;
    public float fuerzaDeGolpe = 4f;
    // public float fuerzaDeSalto = 8f;
    // public bool puedoSaltar;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;
    void Start()
    {
        estoyAtacando = false;
       // puedoSaltar = false;
        anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(!estoyAtacando){
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }
        if(avanzaSolo){
            rb.velocity= transform.forward * fuerzaDeGolpe;
        }
       
    }

    void Update()
    {
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");


        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);


        if (Input.GetKeyDown(KeyCode.Return) && !estoyAtacando)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando = true;
        }
        //     else
        //  {
        //          EstoyCayendo();
        //      }

        if(!estoyAtacando){
            anim.SetFloat("VelX",x);
            anim.SetFloat("VelY",y);
        }
    }

    //  public void EstoyCayendo()
    //  {
    //     anim.SetBool("tocoSuelo", false);
    //    anim.SetBool("salte", false);
    // }
    public void DejeDeGolpear(){
        estoyAtacando = false;
        avanzaSolo = false;
    }
    public void AvanzaSolo(){
        avanzaSolo = true;
    }
    public void DejaDeAvanzar(){
        avanzaSolo = false;
    }
}
