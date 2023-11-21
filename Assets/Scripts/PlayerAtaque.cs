using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtaque : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el jugador presiona la tecla de ataque (por ejemplo, la tecla "Z"), entonces ataca
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        // Activa el trigger de ataque en el Animator
        animator.SetTrigger("Atacar");
    }
}
