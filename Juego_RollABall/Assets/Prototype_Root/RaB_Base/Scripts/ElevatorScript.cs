using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
   
    public float raiseY;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * raiseY * Time.deltaTime);
        transform.Translate(Vector3.down * -raiseY * Time.deltaTime);
    }
}
