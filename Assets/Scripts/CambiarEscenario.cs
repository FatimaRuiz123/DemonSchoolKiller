using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenario : MonoBehaviour
{
    // Nombre del escenario al que se cambiará
    public string nombreEscenario;

    public void CambiarAEscenario()
    {
        // Verificar si se va al Escenario 1
        if (nombreEscenario == "Escenario 1")
        {
            // Detener la reproducción de música al cambiar a este escenario
            AudioManager.Instance.mainAudioSource.Stop();
        }
        else if (nombreEscenario == "Escenario 2")
        {
            // Continuar reproduciendo música al cambiar a este escenario (si se detuvo anteriormente)
            if (!AudioManager.Instance.mainAudioSource.isPlaying)
            {
                AudioManager.Instance.mainAudioSource.Play();
            }
        }

        // Cambiar a otro escenario
        SceneManager.LoadScene(nombreEscenario);
    }
}
