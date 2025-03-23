using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Box2 : MonoBehaviour
{
    public float speed = 1.0f;

    void moveBox(){
        transform.position += Vector3.back * speed;
    
        if (transform.position.z < -1)
        {
            ResetPositions();
        }
    }
    void ResetPositions()
    {
        transform.position = new Vector3(-0.3264122f, -2.28f, 95.7f);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("Car hit the box , i a box number " + gameObject.name);
            
        }
    }
        void Update()
    {
        moveBox();
    }
}
