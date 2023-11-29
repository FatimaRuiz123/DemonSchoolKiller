using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // Referencia al AudioSource del escenario principal
    public AudioSource mainAudioSource;
// Lista de nombres de escenarios donde el sonido debería estar desactivado
    public List<string> scenesWithNoSound;
    void Awake()
    {
        
        // Asegúrate de que solo haya una instancia del objeto persistente
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica si el sonido debería estar desactivado en la escena actual
        bool disableSound = scenesWithNoSound.Contains(scene.name);

        // Activa o desactiva el sonido según la condición
        mainAudioSource.enabled = !disableSound;
    }



    
}
