using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Box2 : MonoBehaviour
{
    private float speed = 0.6f;
    public bool correctOption;
    [SerializeField] public TMP_Text textComponent2;
    private int boxIndex;

    public void SetBoxIndex(int index)
    {
        boxIndex = index;
    }

    void moveBox(){
        transform.position += Vector3.back * speed;
    
        if (transform.position.z < -1)
        {
            ResetPositionBox2();
        }
    }

    public void ResetPositionBox2()
    {
        transform.position = new Vector3(-0.3264122f, -2.28f, 95.7f);
    }

    public int OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Question questionScript = FindObjectOfType<Question>();
            bool isCorrect = questionScript.CheckAnswer(boxIndex);
            FindObjectOfType<Question>().UpdateScore(isCorrect); 
            if (isCorrect)
            {
                Debug.Log("Correct Answer! Box number " + gameObject.name);
                questionScript.GenerateNewQuestion();
            }
            else
            {
                SceneManager.LoadSceneAsync(0);
                Debug.Log("Wrong Answer! Game reset.");
                questionScript.ResetGame();
            }
            return 1;
        }
        return 0;
    }

    void Update()
    {
        moveBox();
    }
}
