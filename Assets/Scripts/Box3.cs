// //this script is attached to Box3 prefab

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Box3 : MonoBehaviour
{
    public float speed = 1.0f;
    public bool correctOption;
    [SerializeField] public TMP_Text textComponent3;

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
    void ResetPositionBox3()
    {
        transform.position = new Vector3(5.249613f, -2.28f, 95.7f);
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
    public void test(){
        Debug.Log("Test");
    }
}
