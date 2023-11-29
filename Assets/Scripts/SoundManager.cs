using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundEffect;

    private void Start()
    {
        // Obtén el componente AudioSource del objeto de sonido
        soundEffect = GetComponent<AudioSource>();
    }

    // Método para reproducir el sonido
    public void PlaySound()
    {
        // Asegúrate de que el AudioSource y el AudioClip estén configurados
        if (soundEffect != null && soundEffect.clip != null)
        {
            soundEffect.PlayOneShot(soundEffect.clip);
        }
    }
}
