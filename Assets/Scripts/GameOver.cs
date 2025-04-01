using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using TMPro;
public class GameOver : MonoBehaviour
{
    public AudioSource src;         
    public AudioClip buttonClick; 
    [SerializeField] TMP_Text scoreText;
    void Start(){
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Score: " + finalScore;
    }
    public void PlayGame()
    {
        StartCoroutine(PlaySoundAndChangeScene());
    }
    // https://stackoverflow.com/questions/72331573/sound-when-button-switch-scene

    private IEnumerator PlaySoundAndChangeScene()
    {
        src.PlayOneShot(buttonClick);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync(0);
    }
}
