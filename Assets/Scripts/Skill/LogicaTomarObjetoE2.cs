using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaTomarObjetoE2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other){
        if(other.tag == "Skill" && other.GetComponent<LogicaPotenciadorE2>().destruirAutomatico==true){
            other.GetComponent<LogicaPotenciadorE2>().Efecto();
            Destroy(other.gameObject);
        }
    }
}
