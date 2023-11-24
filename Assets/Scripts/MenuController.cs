using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void LoadNivel1(){
        SceneManager.LoadScene("Escenario 1");
    }
 public void LoadNivel2(){
        SceneManager.LoadScene("Escenario 2");
    }
    public void LoadAtras(){
        SceneManager.LoadScene("Menu");
    }
public void LoadReglas(){
        SceneManager.LoadScene("Reglas");
    }

    public void Salir(){
        Application.Quit();
    }
}
