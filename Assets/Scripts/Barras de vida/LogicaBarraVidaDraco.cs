using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicaBarraVidaDraco : MonoBehaviour
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

        if (vidaActual <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Win2");
        }
    }

    void RevisarVida()
    {
        imagenBarraVida.fillAmount = vidaActual / vidaMax;
    }
}
