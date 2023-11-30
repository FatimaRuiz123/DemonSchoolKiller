using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPotenciador : MonoBehaviour
{
    public bool destruirAutomatico;
    public PlayerController logicaJaziel;

    public int tipo;

    // Start is called before the first frame update
    void Start()
    {
        logicaJaziel = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destruirAutomatico)
        {
            Destroy(gameObject, 5f); // Destruye el objeto después de 5 segundos (puedes ajustar el tiempo según sea necesario)
        }
    }

    public void Efecto()
    {
        switch (tipo)
        {
            case 1:
                logicaJaziel.velocidadMovimiento += 5;
                break;
            case 2:
                logicaJaziel.velocidadMovimiento -= 5;
                break;
            default:
                Debug.Log("Sin potenciador");
                break;
        }
    }
}
