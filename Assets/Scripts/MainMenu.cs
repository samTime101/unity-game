    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MainMenu : MonoBehaviour
    {
        public AudioSource src;         
        public AudioClip buttonClick;   
    // https://stackoverflow.com/questions/72331573/sound-when-button-switch-scene
        public void PlayGame()
        {
            StartCoroutine(PlaySoundAndChangeScene());
        }

        private IEnumerator PlaySoundAndChangeScene()
        {
            src.PlayOneShot(buttonClick);

            yield return new WaitForSeconds(0.2f);

            SceneManager.LoadSceneAsync(1);
        }
    }
