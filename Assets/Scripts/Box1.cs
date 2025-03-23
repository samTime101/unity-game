using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Box1 : MonoBehaviour
{
    public float speed = 1.0f;

    void moveBox() {
        transform.position += Vector3.back * speed;
    
        if (transform.position.z < -1)
        {
            ResetPositions();
        }
    }
    void ResetPositions()
    {
        transform.position = new Vector3(-6.043173f, -2.28f, 95.7f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("Car hit the box, I am box number " + gameObject.name);
            
        }
        //
    }
        void Update()
    {
        moveBox();
    }
}
