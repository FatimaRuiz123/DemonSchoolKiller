using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarArmasE2 : MonoBehaviour
{
    public BoxCollider[] armasBoxCol;
    public BoxCollider puñoBoxCol;
    public PlayerControllerE2 playerControllerE2;
    public GameObject[] armas;
    // Start is called before the first frame update
    void Start()
    {
            DesactivarCollidersArmas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarArmas(int numero){
        for(int i=0; i< armas.Length; i++){
            armas[i].SetActive(false);
        }

        armas[numero].SetActive(true);
        playerControllerE2.conArma = true;
    }

     public void ActivarCollidersArmas(){
        for(int i = 0; i < armasBoxCol.Length; i++){
            if(playerControllerE2.conArma){
               if(armasBoxCol[i] != null){
                    armasBoxCol[i].enabled = true;
               }
            }
        }
    }
     public void DesactivarCollidersArmas(){
        for(int i = 0; i < armasBoxCol.Length; i++){
            if(armasBoxCol[i] != null){
                armasBoxCol[i].enabled = false;
            }
        }
    }
}
