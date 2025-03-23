//this script is attached to Box1 prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box1 : MonoBehaviour
{
    public float speed = 1.0f;
    [SerializeField] public TMP_Text textComponent1;

    void moveBox() {
        transform.position += Vector3.back * speed; 
    
        if (transform.position.z < -1)
        {
            ResetPositionBox1();
        }
    }

    void ResetPositionBox1()
    {
        transform.position = new Vector3(-6.043173f, -2.28f, 95.7f);
    }

    public int OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("Car hit the box, I am box number " + gameObject.name);
            return 1;
        }
        return 0;
    }

    void Update()
    {
        moveBox();
    }

}
