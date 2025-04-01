using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Question : MonoBehaviour
{
    [SerializeField] GameObject box1;
    [SerializeField] GameObject box2;
    [SerializeField] GameObject box3;
    [SerializeField] GameObject car;

    [SerializeField] public TMP_Text questionText;
    [SerializeField] public TMP_Text scoreText;
    
    private int correctAnswerIndex;
    private int score = 0;
    private OperationType currentOperation;

    private enum OperationType { Addition, Subtraction, Multiplication }

    void Start()
    {
        int operationIndex = PlayerPrefs.GetInt("SelectedOperation", 1); 
        currentOperation = (OperationType)operationIndex;
        GenerateNewQuestion();
    }

    public void GenerateNewQuestion()
    {
        int num1 = UnityEngine.Random.Range(1, 11);
        int num2 = UnityEngine.Random.Range(1, 11);
        int correctAnswer = 0;
        string operationSymbol = "";

        switch (currentOperation)
        {
            case OperationType.Addition:
                correctAnswer = num1 + num2;
                operationSymbol = " + ";
                break;
            case OperationType.Subtraction:
                correctAnswer = num1 - num2;
                operationSymbol = " - ";
                break;
            case OperationType.Multiplication:
                correctAnswer = num1 * num2;
                operationSymbol = " × ";
                break;
        }

        questionText.text = "What is " + num1 + operationSymbol + num2 + "?";

        List<int> options = new List<int> { correctAnswer };

        while (options.Count < 3)
        {
            int newOption = UnityEngine.Random.Range(1, 21);
            if (!options.Contains(newOption)) 
            {
                options.Add(newOption);
            }
        }

        for (int i = 0; i < options.Count; i++)
        {
            int temp = options[i];
            int randomIndex = UnityEngine.Random.Range(i, options.Count);
            options[i] = options[randomIndex];
            options[randomIndex] = temp;
        }

        box1.GetComponent<Box1>().textComponent1.text = options[0].ToString();
        box2.GetComponent<Box2>().textComponent2.text = options[1].ToString();
        box3.GetComponent<Box3>().textComponent3.text = options[2].ToString();

        if (box1.GetComponent<Box1>().textComponent1.text == correctAnswer.ToString()) correctAnswerIndex = 0;
        else if (box2.GetComponent<Box2>().textComponent2.text == correctAnswer.ToString()) correctAnswerIndex = 1;
        else correctAnswerIndex = 2;

        box1.GetComponent<Box1>().SetBoxIndex(0);
        box2.GetComponent<Box2>().SetBoxIndex(1);
        box3.GetComponent<Box3>().SetBoxIndex(2);
    }

    public bool CheckAnswer(int boxIndex)
    {
        return boxIndex == correctAnswerIndex;
    }

    public void UpdateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;  
        }
        else
        {
            PlayerPrefs.SetInt("FinalScore", score);  
            PlayerPrefs.Save(); 
            score = 0;  
        }
        
        scoreText.text = "Score: " + score.ToString();
    }

    public void ResetGame()
    {
        box1.GetComponent<Box1>().ResetPositionBox1();
        box2.GetComponent<Box2>().ResetPositionBox2();
        box3.GetComponent<Box3>().ResetPositionBox3();
        GenerateNewQuestion();
    }
}
