using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
//public static MenuController instance;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
    public void LoadNivel1()
    {
        SceneManager.LoadScene("Escenario 1");
    }
    public void LoadNivel2()
    {
        SceneManager.LoadScene("Escenario 2");
    }

    public void LoadH1()
    {
        SceneManager.LoadScene("Historia");
    }
    public void LoadH2()
    {
        SceneManager.LoadScene("Historia 2");
    }
    public void LoadAtras()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadReglas()
    {
        SceneManager.LoadScene("Reglas");
    }
    public void LoadAtras2()
    {
        SceneManager.LoadScene("MenuInicial");
    }
    public void LoadTop()
    {
        SceneManager.LoadScene("Top 10");
    }


    public void Salir()
    {
        Application.Quit();
    }
    public void StopSound()
    {
        // Detén el sonido
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }


}


