using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box1 : MonoBehaviour
{
    private float speed = 0.6f;
    [SerializeField] public TMP_Text textComponent1;
    private int boxIndex;

    public void SetBoxIndex(int index)
    {
        boxIndex = index;
    }

    void moveBox() {
        transform.position += Vector3.back * speed; 
    
        if (transform.position.z < -1)
        {
            ResetPositionBox1();
        }
    }

    // Change to public to allow access from other scripts
    public void ResetPositionBox1()
    {
        transform.position = new Vector3(-6.043173f, -2.28f, 95.7f);
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
