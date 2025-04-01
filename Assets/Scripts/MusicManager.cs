using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    private AudioSource audioSource;

    void Awake()
    {
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;  
            audioSource.Play();
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "gameplay" || SceneManager.GetActiveScene().name == "gameOver")
        {
            audioSource.Stop();
        }
        else if (!audioSource.isPlaying) 
        {
            audioSource.Play();
        }
    }
}
