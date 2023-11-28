using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(1,4,-5);
    // Start is called before the first frame update
    void Start()
    {
        
    }

      // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset;

        // Rotate the camera to match the player's rotation
        transform.rotation = player.transform.rotation;
    }
    
}
