using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 20.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;
    void Start()
    {
        puedoSaltar = false;
        anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
    }

    void Update()
{
    y = Input.GetAxis("Vertical");
    x = Input.GetAxis("Horizontal");

    anim.SetFloat("VelX", x);
    anim.SetFloat("VelY", y);

    if (puedoSaltar && Input.GetKeyDown(KeyCode.Space))
    {
        anim.SetBool("salte", true);
        rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
        puedoSaltar = false; // Evitar múltiples saltos
    }
    else
    {
        EstoyCayendo();
    }
}

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }
}
