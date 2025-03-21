using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, -10, 0);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
                        transform.rotation = Quaternion.Euler(0, 10, 0);

        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)){
            GetComponent<Rigidbody>().velocity  = Vector3.zero;

        }
    }
}
