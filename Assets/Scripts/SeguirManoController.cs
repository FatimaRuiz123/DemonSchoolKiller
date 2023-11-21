using UnityEngine;

public class SeguirManoController : MonoBehaviour
{
    public Transform manoDelPersonaje; // Asigna la mano del personaje en la pose T desde el Inspector

    void Update()
    {
        // Asegurarse de que la mano del personaje esté asignada
        if (manoDelPersonaje != null)
        {
            // Actualizar la posición y rotación del punto de anclaje para seguir la mano
            transform.position = manoDelPersonaje.position;
            transform.rotation = manoDelPersonaje.rotation;
        }
    }
}
