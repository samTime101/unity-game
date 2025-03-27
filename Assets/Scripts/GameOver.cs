using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using TMPro;
public class GameOver : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    void Start(){
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Score: " + finalScore;
    }
    public void PlayGame(){
        // show the score also
        SceneManager.LoadSceneAsync(0);
    }
}
