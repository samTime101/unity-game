// //this script is attached to Box2 prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Box2 : MonoBehaviour
{
    public float speed = 1.0f;
    public bool correctOption;
    [SerializeField] public TMP_Text textComponent2;

    void moveBox(){
        transform.position += Vector3.back * speed;
    
        if (transform.position.z < -1)
        {
            ResetPositionBox2();
        }
    }
    void ResetPositionBox2()
    {
        transform.position = new Vector3(-0.3264122f, -2.28f, 95.7f);
    }
    
    public int OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("Car hit the box , i a box number " + gameObject.name);
            return 1;
            
        }
        return 0;
    }
        void Update()
    {
        moveBox();
    }
}
