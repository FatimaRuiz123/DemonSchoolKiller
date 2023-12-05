using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaBarraVidaIris : MonoBehaviour
{
     public int vidaMax;
    public float vidaActual;
    public Image imagenBarraVida;
    

    void Start()
    {
        vidaActual = vidaMax;
    }

    void Update()
    {
        RevisarVida();

        float umbral = 0.001f;

    if (vidaActual <= umbral)
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Win 1");
    }

    }

    void RevisarVida()
    {
        imagenBarraVida.fillAmount = vidaActual / vidaMax;
    }
}
