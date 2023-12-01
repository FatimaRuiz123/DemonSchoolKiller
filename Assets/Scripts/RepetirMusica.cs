using UnityEngine;

public class RepetirMusica : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obtén el componente AudioSource adjunto al objeto
        audioSource = GetComponent<AudioSource>();

        // Suscríbete al evento de finalización de la reproducción
        audioSource.Play();
        audioSource.loop = false; // Asegúrate de que el bucle esté desactivado inicialmente
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + audioSource.clip.length); // Establece el tiempo de finalización
        audioSource.loop = true; // Activa el bucle después de que la reproducción haya finalizado
    }
}
