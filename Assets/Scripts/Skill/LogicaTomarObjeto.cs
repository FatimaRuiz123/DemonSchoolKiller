using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaTomarObjeto : MonoBehaviour
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
        if(other.tag == "Skill" && other.GetComponent<LogicaPotenciador>().destruirAutomatico==true){
            other.GetComponent<LogicaPotenciador>().Efecto();
            Destroy(other.gameObject);
        }
    }
}
