using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box3 : MonoBehaviour
{
    public float speed = 1.0f;
    public bool correctOption;
    [SerializeField] public TMP_Text textComponent3;
    private int boxIndex;

    public void SetBoxIndex(int index)
    {
        boxIndex = index;
    }

    void moveBox(){
        transform.position += Vector3.back * speed;
        checkPosition();
    }

    void checkPosition(){
        if (transform.position.z < -1)
        {
            ResetPositionBox3();
        }
    }

    public void ResetPositionBox3()
    {
        transform.position = new Vector3(5.249613f, -2.28f, 95.7f);
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
