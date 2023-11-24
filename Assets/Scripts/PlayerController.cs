using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody playerRigidbody;
    float verInput;
    float horInput;
    bool isGrounded;
    bool isAttacking;

    public Camera playerCamera;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        isGrounded = true;
        isAttacking = false;
    }

    void Update()
    {
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            animator.SetInteger("Est", 2);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            isAttacking = true;
            animator.SetTrigger("Atacar");
        }
        else if (isAttacking && Input.GetKeyUp(KeyCode.Z))
        {
            isAttacking = false;
            animator.SetInteger("Est", 0); // Idle
        }

        if (!isAttacking)
        {
            if (verInput == 0 && horInput == 0 && isGrounded)
            {
                animator.SetInteger("Est", 0); // Idle
            }
            else
            {
                // Calcula la dirección del movimiento
                Vector3 moveDirection = new Vector3(horInput, 0, verInput).normalized;

                // Aplica la dirección al Rigidbody del jugador
                playerRigidbody.MovePosition(transform.position + moveDirection * Time.deltaTime * 10);

                // Gira a la izquierda o derecha
                transform.Rotate(Vector3.up * horInput * 100 * Time.deltaTime);

                if (playerCamera != null)
                {
                    playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + (-5f), transform.position.z - 5f);
                    playerCamera.transform.LookAt(transform.position);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
