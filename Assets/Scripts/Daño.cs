using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public LogicaBarraVidaJaziel logicaBarraVidaJaziel;
    public LogicaBarraVidaDeminios logicaBarraVidaDemonio;
    public LogicaBarraVidaDeminios logicaBarraVidaIris;
    public float dañoD = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            logicaBarraVidaJaziel.vidaActual -= dañoD;
            logicaBarraVidaDemonio.vidaActual -= dañoD;
            logicaBarraVidaIris.vidaActual -= dañoD;
        }
    }
}
